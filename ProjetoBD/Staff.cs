using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjetoBD
{
    [Serializable()]
    internal class Staff
    {
        private String _nFunc;
        private String _CC;
        private String _Fname;
        private String _Lname;
        private String _Email;
        private String _Telemovel;
        private String _NIF;
        private String _Morada;
        private String _Data_Nasc;
        private String _Data_Contrat;
        private String _Salario;
        private String _NGerente;
        private String _Horario;
        private String _Cargo;

        public String NFunc
        {
            get { return _nFunc; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("O número de funcionário não pode ser vazio.");
                    return;
                }

                _nFunc = value;
            }
        }

        public String CC
        {
            get { return _CC; }
            set
            {
                if (value == null | String.IsNullOrEmpty(value))
                {
                    throw new Exception("CC do funcionário não pode ser vazio.");
                    return;
                }

                _CC = value;
            }
        }

        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public String Telemovel
        {
            get { return _Telemovel; }
            set { _Telemovel = value; }
        }

        public String NIF
        {
            get { return _NIF; }
            set { _NIF = value; }
        }

        public String Data_Nasc
        {
            get { return _Data_Nasc; }
            set { _Data_Nasc = value; }
        }

        public String Morada
        {
            get { return _Morada; }
            set { _Morada = value; }
        }

        public String Fname
        {
            get { return _Fname; }
            set { _Fname = value; }
        }
        public String Lname
        {
            get { return _Lname; }
            set { _Lname = value; }
        }

        public String Data_Contrat
        {
            get { return _Data_Contrat; }
            set { _Data_Contrat = value; }
        }

        public String Salario
        {
            get { return _Salario; }
            set { _Salario = value; }
        }

        public String NGerente
        {
            get { return _NGerente; }
            set { _NGerente = value;}
        }

        public String Horario
        {
            get { return _Horario; }
            set { _Horario = value; }
        }

        public String Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }



        public override string ToString()
        {
            return  _nFunc + " - " + _Fname + " " + _Lname;
        }

        public Staff() : base() { }

    }
}