using System;
using System.Collections.Generic;
using System.Text;
using MySpotify.Models;

namespace MySpotify.Data.Interfaces
{
    public interface ILogsService
    {
        HandledException HandleException(Exception ex, string errorTitle, string errorMessage, string origin);
        Log HandleLog(Log l);
    }
}
