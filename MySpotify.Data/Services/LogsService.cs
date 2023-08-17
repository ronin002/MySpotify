using System;
using System.Collections.Generic;
using System.Text;

using MySpotify.Data.Interfaces;
using MySpotify.Models;
using MySpotify.Models.Enums;

namespace MySpotify.Data.Services
{
    public class LogsService: ILogsService
    {
        public ILogsRepository LogsRepository { get; set; }

        public LogsService(ILogsRepository logsRepository)
        {
            LogsRepository = logsRepository;
        }

        public HandledException HandleException(Exception exception, 
                                                 string errorTitle, 
                                                 string errorMessage, 
                                                 string origin)
        {
            try
            {
                HandledException e = new HandledException(exception, errorTitle, errorMessage);
                //Get userId and sessionId
                int userId = 0;
                Guid sessionId = Guid.NewGuid();
                var trace = exception.InnerException != null ? exception.InnerException.Message : exception.StackTrace;
                var message = $"({origin}) {errorTitle} - {errorMessage} = {trace}";
                message = message.Length >= 511 ? message.Substring(0, 511) : message;
                Log log = new Log()
                {
                    Class = LogType.Error,
                    Message = message,
                    SessionId = sessionId,
                    TimeStamp = DateTime.UtcNow,
                    UserId = userId
                };

                Console.Write($"{log.Message} / {e.TargetSite}");

                LogsRepository.Add(log);

                return e;

            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.Class = LogType.Error;
                if (errorMessage.Length > 500)
                    log.Message = "Error when logging." + errorMessage.Substring(0, 500);
                else
                    log.Message = "Error when logging." + errorMessage;

                log.SessionId = Guid.NewGuid();
                log.TimeStamp = DateTime.UtcNow;
                log.UserId = 0;

                /*
                Log log = new Log()
                {
                    Class = LogType.Error,
                    Message = "Error when logging." + errorMessage.Substring(0, 500),
                    SessionId = Guid.NewGuid(),
                    TimeStamp = DateTime.UtcNow,
                    UserId = 0
                };
                */

                LogsRepository.Add(log);
            }

            return null;
        }

        public Log HandleLog(Log l)
        {
            LogsRepository.Add(l);
            return l;   
        }
    }
}
