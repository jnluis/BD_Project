using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBD
{
    [Serializable()]
    public class Cliente
    {
        private String _CC;
        private String _Fname;
        private String _Lname;
        private String _Email;
        private String _Telemovel;
        private String _NIF;
        private String _Morada;
        private String _Data_Nasc;

        public String CC
        {
            get { return _CC; }
            set 
            { 
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("CC do cliente não pode ser vazio.");
                    return;
                }

                _CC = value; 
            }
        }

        public String Email
        { 
            get { return _Email; }
            set { _Email= value; }
        }

        public String Telemovel
        {
            get { return _Telemovel; }
            set { _Telemovel= value; }
        }

        public String NIF
        {
            get { return _NIF; }
            set { _NIF= value; }
        }

        public String Data_Nasc
        {
            get { return _Data_Nasc;}
            set { _Data_Nasc= value;}
        }

        public String Morada
        {
            get { return _Morada; }
            set { _Morada = value; }
        }

        public String Fname
        {
            get { return _Fname; }
            set { _Fname= value; }
        }
        public String Lname
        {
            get { return _Lname; }
            set { _Lname = value; }
        }


        public override string ToString()
        {
            return _CC + " - " + _Fname + " " + _Lname;
        }

        public Cliente() : base() { }

    }
    
}
