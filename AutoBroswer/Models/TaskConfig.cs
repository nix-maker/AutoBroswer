using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBroswer.Models
{
    public class TaskConfig
    {
        /// <summary>
        /// page url
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// execute times
        /// </summary>
        public int Times { get; set; } = 0;

        /// <summary>
        /// execute js function return string to save
        /// </summary>
        public string ExecJSFunction { get; set; }

        public bool IsSaveToDatabase { get; set; }

        public int WaitSeconds { get; set; }

        /// <summary>
        /// when ExecJSFunction return null wait 
        /// </summary>
        public int ErrorWaitSeconds { get; set; }
        /// <summary>
        /// when null mouseWheel to bottom else click next page
        /// </summary>
        public string NextPageSelector { get; set; }



    }
}
