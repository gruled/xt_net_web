using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Task05
{
    class BackUpSystem
    {
        private string _dir;
        private string _logFile;
        private Mode _mode;
        private bool _observerRunning;
        private List<Operation> _operations;
        private Queue<Operation> _bufQueue;

        public void Start()
        {
            _bufQueue = new Queue<Operation>();
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            _observerRunning = false;
            _dir = SetDir();
            //_dir = "E:\\Test";
            _logFile = SetLogFile();
            //_logFile = "E:\\Test\\abc.json";
            _mode = SetMode();
            _operations = new List<Operation>();
            switch (_mode)
            {
                case Mode.Observer:
                    _startObserverThread();
                    break;
                case Mode.RollBack:
                    _rollBack();
                    Console.WriteLine("BackUp complete");
                    break;
            }
        }

        #region InitPath&Etc

        protected virtual string SetDir()
        {
            Console.Write("Path to target directory: ");
            string value = Console.ReadLine();
            if (Directory.Exists(value))
            {
                return value;
            }
            else
            {
                throw new DirectoryNotFoundException(value);
            }
        }

        protected virtual string SetLogFile()
        {
            Console.Write("Path and name to log file: ");
            string value = Console.ReadLine();
            return value;
        }

        protected virtual Mode SetMode()
        {
            Console.Write("Mode (1- observer, 2-roll back): ");
            int i = default;
            if (int.TryParse(Console.ReadLine(), out i))
            {
                switch (i)
                {
                    case 1: return Mode.Observer;
                    case 2: return Mode.RollBack;
                    default: throw new ArgumentOutOfRangeException("Value must be from 1 to 2");
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private List<Operation> _filList()
        {
            if (File.Exists(_logFile))
            {
                string value = default;
                value = _getValueFromFile(_logFile);
                return JsonConvert.DeserializeObject<List<Operation>>(value);
            }

            return new List<Operation>();
        }

        private string _getValueFromFile(string fullPath)
        {
            string value = default;

            Stream sr;
            using (sr = File.Open(fullPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                StreamReader reader = new StreamReader(sr);
                value = reader.ReadToEnd();
                reader.Close();
            }

            return value;
        }

        #endregion

        #region Observer

        private void _startObserverThread()
        {
            Thread threadObserver = new Thread(_observer);
            threadObserver.Start();
            Thread threadBuf = new Thread(_bufferOperations);
            threadBuf.Start();
            Thread threadBreakObserver = new Thread(_breakObserver);
            threadBreakObserver.Start();
        }

        private void _bufferOperations()
        {
            while (true)
            {
                if (_bufQueue.Count > 0)
                {
                    Operation op = _bufQueue.Dequeue();
                    string value;
                    if (op.Type == TypeOperation.Update)
                    {
                        try
                        {
                            value = _getValueFromFile(op.File);
                        }
                        catch (IOException)
                        {
                            Thread.Sleep(1); //due to previously file operation need some time to close
                            value = _getValueFromFile(op.File);
                        }
                    }
                    else
                    {
                        value = op.Value;
                    }

                    _operations.Add(new Operation(op.Time, op.File, op.Type, value));
                }
            }
        }

        private void _observer()
        {
            _observerRunning = true;
            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher(_dir);
            fileSystemWatcher.EnableRaisingEvents = true;
            fileSystemWatcher.Filter = "*.txt";
            fileSystemWatcher.IncludeSubdirectories = true;
            fileSystemWatcher.Renamed += OnObserverRename;
            fileSystemWatcher.Changed += OnObserverUpdate;
            fileSystemWatcher.Created += OnObserverCreate;
            fileSystemWatcher.Deleted += OnObserverDelete;
            while (_observerRunning)
            {
                Thread.Sleep(500);
            }

            _save();
        }

        private void _save()
        {
            Console.WriteLine("Start save in log file");
            StringBuilder sb = new StringBuilder();
            if (File.Exists(_logFile))
            {
                sb.Append(_getValueFromFile(_logFile));
            }

            string addValue = JsonConvert.SerializeObject(_operations);
            sb.Append(addValue);
            string res = sb.Replace("][", ",").ToString();

            using (StreamWriter sw = new StreamWriter(_logFile, false))
            {
                sw.Write(res);
            }

            Console.WriteLine("Stop save in log file");
        }

        private void _breakObserver()
        {
            Console.Write("0 - exit: ");
            string value = Console.ReadLine();
            if (value != null)
            {
                if (value.Equals("0") || value.Equals("exit"))
                {
                    _observerRunning = false;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        private void OnObserverRename(object sender, RenamedEventArgs e)
        {
            _bufQueue.Enqueue(new Operation(DateTime.Now, e.OldFullPath, TypeOperation.Rename, e.FullPath));
        }

        private void OnObserverUpdate(object sender, FileSystemEventArgs e)
        {
            _bufQueue.Enqueue(new Operation(DateTime.Now, e.FullPath, TypeOperation.Update, ""));
        }

        private void OnObserverCreate(object sender, FileSystemEventArgs e)
        {
            _bufQueue.Enqueue(new Operation(DateTime.Now, e.FullPath, TypeOperation.Create, ""));
        }

        private void OnObserverDelete(object sender, FileSystemEventArgs e)
        {
            _bufQueue.Enqueue(new Operation(DateTime.Now, e.FullPath, TypeOperation.Delete, ""));
        }

        #endregion

        #region RollBAck

        private void _rollBack()
        {
            DateTime targetDateTime = _targetDateTimeInput();
            _startBack(targetDateTime);
        }

        protected virtual DateTime _targetDateTimeInput()
        {
            Console.Write("Target date  ");
            _operations = _filList();
            var times = _operations.Select(x => x.Time);
            Console.WriteLine();
            int count = 0;
            foreach (var time in times)
            {
                Console.WriteLine(count + ": " + time.ToString("dd.MM.yyyy HH:mm:ss:fff"));
                count++;
            }

            DateTime d = _getDateTimeFromInt(0, times.Count());
            return d + new TimeSpan((long)1);
        }

        private DateTime _getDateTimeFromInt(int min, int max)
        {
            Console.Write("Target date(number): ");
            int i;
            if (int.TryParse(Console.ReadLine(), out i))
            {
                if (i <= max && i >= min)
                {
                    _operations = _filList();
                    int myCount = 0;
                    foreach (var item in _operations)
                    {
                        if (myCount == i)
                        {
                            return item.Time;
                        }

                        myCount++;
                    }
                }

                throw new ArgumentOutOfRangeException("date",
                    "This value must equals or greather then " + min + " and equals or less than " + max);
            }
            else
            {
                throw new InvalidCastException("This value not cast to int");
            }
        }

        private void _startBack(DateTime d)
        {
            _operations = _filList();
            List<Operation> reverseOperations = new List<Operation>();
            for (int i = _operations.Count - 1; i >= 0; i--)
            {
                reverseOperations.Add(_operations[i]);
            }

            foreach (var operation in reverseOperations)
            {
                switch (operation.Type)
                {
                    case TypeOperation.Create:
                        _operations.Add(new Operation(DateTime.Now, operation.File, TypeOperation.Delete, ""));
                        File.Delete(operation.File);
                        break;
                    case TypeOperation.Rename:
                        _operations.Add(new Operation(DateTime.Now, operation.File, TypeOperation.Create, ""));
                        _operations.Add(new Operation(DateTime.Now, operation.File, TypeOperation.Update,
                            _getValueFromFile(operation.Value)));
                        _operations.Add(new Operation(DateTime.Now, operation.Value, TypeOperation.Delete, ""));
                        File.Copy(operation.Value, operation.File);
                        File.Delete(operation.Value);
                        break;
                    case TypeOperation.Update:
                        using (StreamWriter sw = new StreamWriter(operation.File, false))
                        {
                            string value = _getValueInPast(reverseOperations, operation.Time, operation.File);
                            sw.Write(value);
                            _operations.Add(new Operation(DateTime.Now, operation.File, TypeOperation.Update, value));
                            sw.Flush();
                            sw.Close();
                        }

                        break;
                    case TypeOperation.Delete:
                        if (!File.Exists(operation.File))
                        {
                            _operations.Add(new Operation(DateTime.Now, operation.File, TypeOperation.Create, ""));
                            File.Create(operation.File).Close();
                        }

                        using (StreamWriter sw = new StreamWriter(operation.File, false))
                        {
                            string value = _getValueInPast(reverseOperations, operation.Time, operation.File);
                            sw.Write(value);
                            _operations.Add(new Operation(DateTime.Now, operation.File, TypeOperation.Update, value));
                            sw.Flush();
                            sw.Close();
                        }

                        break;
                }

                if (operation.Time <= d)
                {
                    break;
                }
            }

            _saveRoll();
        }

        private void _saveRoll()
        {
            StringBuilder sb = new StringBuilder();

            string addValue = JsonConvert.SerializeObject(_operations);
            sb.Append(addValue);
            string res = sb.Replace("][", ",").ToString();

            using (StreamWriter sw = new StreamWriter(_logFile, false))
            {
                sw.Write(res);
            }
        }

        private string _getValueInPast(List<Operation> operations, DateTime d, string file)
        {
            var op = operations.Where(x => x.Time <= d).Where(x => file.Equals(x.File))
                .Where(x => x.Type == TypeOperation.Update);
            if (op.Any())
            {
                return op.First().Value;
            }
            else
            {
                return "";
            }
        }

        #endregion

    }
}
