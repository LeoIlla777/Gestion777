namespace Lfx
{
        /// <summary>
        /// Proporciona servicios de comunicación inter-proceso (entre el Lfx, la aplicación principal y los componentes)
        /// </summary>
        public class RunTimeServices
        {
                public class IpcEventArgs : System.EventArgs
                {
                        public enum EventTypes
                        {
                                Undefined,
                                Information,
                                Progress,
                                ActionRequest,
                                Notification
                        }

                        public EventTypes EventType = EventTypes.Undefined;
                        public string Source;
                        public string Destination;
                        public string Verb;
                        public object[] Arguments;
                        public object ReturnValue;

                        public IpcEventArgs() { }
                        public IpcEventArgs(EventTypes eventType)
                        {
                                this.EventType = eventType;
                        }
                }

                public delegate void IpcEventHandler(object sender, ref IpcEventArgs e);
                public event IpcEventHandler IpcEvent;

                public object Execute(string verb)
                {
                        return this.Execute("gestion777", verb, null);
                }

                public object Execute(string verb, object[] arguments)
                {
                        return this.Execute("gestion777", verb, arguments);
                }

                public object Execute(string destination, string verb, object[] arguments)
                {
                        if (IpcEvent != null) {
                                IpcEventArgs e = new IpcEventArgs();
                                e.EventType = IpcEventArgs.EventTypes.ActionRequest;
                                e.Destination = destination;
                                e.Verb = verb;
                                e.Arguments = arguments;
                                this.IpcEvent(this, ref e);
                                return e.ReturnValue;
                        }
                        return null;
                }


                public void Notify(string destination, object notification)
                {
                        IpcEventArgs e = new IpcEventArgs();
                        e.EventType = IpcEventArgs.EventTypes.Notification;
                        e.Destination = destination;
                        e.Arguments = new object[] { notification };
                        this.IpcEvent(this, ref e);
                }


                public void Info(string verb, string infoText)
                {
                        this.Info("gestion777", verb, new object[] { infoText });
                }


                public void Info(string verb, object[] arguments)
                {
                        this.Info("gestion777", verb, arguments);
                }

                public void Info(string destination, string verb, string infoText)
                {
                        this.Info(destination, verb, new object[] { infoText });
                }

                public void Info(string destination, string verb, object[] arguments)
                {
                        if (IpcEvent != null) {
                                IpcEventArgs e = new IpcEventArgs();
                                e.EventType = IpcEventArgs.EventTypes.Information;
                                e.Destination = destination;
                                e.Verb = verb;
                                e.Arguments = arguments;
                                this.IpcEvent(this, ref e);
                        }
                }

                public void NotifyProgress(Lfx.Types.OperationProgress progress)
                {
                        if (IpcEvent != null) {
                                IpcEventArgs e = new IpcEventArgs();
                                e.EventType = IpcEventArgs.EventTypes.Progress;
                                e.Destination = "gestion777";
                                e.Verb = "PROGRESS";
                                e.Arguments = new object[] { progress };
                                this.IpcEvent(this, ref e);
                        }
                }


                public void Toast(string messageText, string caption)
                {
                        if (IpcEvent != null) {
                                IpcEventArgs e = new IpcEventArgs();
                                e.EventType = IpcEventArgs.EventTypes.Information;
                                e.Destination = "gestion777";
                                e.Verb = "TOAST";
                                e.Arguments = new object[] { messageText, caption };
                                this.IpcEvent(this, ref e);
                        }
                }


                public void Hint(string messageText, string caption)
                {
                        if (IpcEvent != null) {
                                IpcEventArgs e = new IpcEventArgs();
                                e.EventType = IpcEventArgs.EventTypes.Information;
                                e.Destination = "gestion777";
                                e.Verb = "HINT";
                                e.Arguments = new object[] { messageText, caption };
                                this.IpcEvent(this, ref e);
                        }
                }

                public void Paging(object form)
                {
                    if (IpcEvent != null)
                    {
                        IpcEventArgs e = new IpcEventArgs();
                        e.EventType = IpcEventArgs.EventTypes.Information;
                        e.Destination = "gestion777";
                        e.Verb = "PAGE";
                        e.Arguments = new object[] { form };
                        this.IpcEvent(this, ref e);
                    }
                }


                public void Paging(int currentPage, int TotalPage)
                {
                    if (IpcEvent != null)
                    {
                        IpcEventArgs e = new IpcEventArgs();
                        e.EventType = IpcEventArgs.EventTypes.Information;
                        e.Destination = "gestion777";
                        e.Verb = "PAGEUPD";
                        e.Arguments = new object[] { currentPage, TotalPage };
                        this.IpcEvent(this, ref e);
                    }
                }
    }
}
