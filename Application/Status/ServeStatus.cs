using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Status
{
    public class ServeStatus
    {
        public string Massege { get; set; }
        public List<string> Erros { get; set; }

        private ServeStatus() { }

        public ServeStatus(string massege)
        {
            Massege = massege;
        }
        public ServeStatus(List<string> erros)
        {
            Erros = new List<string>();
            Erros.AddRange(erros);
        }
    }
}
