namespace Tools
{
    public sealed class Log
    {
        private static Log _instance = null;
        private string _path;
        private static object _protect = new object();

        public static Log GetInstance(string path)
        {
            /*
             lock es una palabra reservada que hace que mientras se esta trabajando con varios hilos.
                revisa que si ya hay un hilo trabajando con ese atributo no puede trabajar otro hilo
            de esta manera podemos evitar que si se trabaja de manera asincrona se cree 2 objetos.
             */
            lock(_protect)
            {
                if (_instance == null)
                {
                    _instance = new Log(path);
                }

            }
           
            return _instance;
        }

        public static Log Instance 
        { 
            get 
            { 
                return _instance; 
            } 
        }

        private Log(string path) 
        {
            this._path = path;
        }

        public void Save(string message)
        {
            File.AppendAllText(_path, message + Environment.NewLine);
        }
    }
}
