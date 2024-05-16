using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MED_X
{
    internal class XMLDoctor
    {
        private XmlDocument XDoc = new XmlDocument();
        private XmlElement XRoot;

        public XMLDoctor()
        {
            XDoc.Load("doctors.xml");
            XRoot = XDoc.DocumentElement;
        }

        public List<Doctor> GetAllDoctors()
        {
            var doctors = new List<Doctor>();

            if (XRoot != null)
            {
                foreach (XmlElement xnode in XRoot)
                {
                    Doctor doctor = new Doctor();
                    XmlNode attr = xnode.Attributes.GetNamedItem("login");
                    doctor.ChangeLogin(attr.Value);

                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "name")
                        {
                            doctor.ChangeName(childnode.InnerText);
                        }
                        if (childnode.Name == "secondName")
                        {
                            doctor.ChangeSecondName(childnode.InnerText);
                        }
                        if (childnode.Name == "surname")
                        {
                            doctor.ChangeSurname(childnode.InnerText);
                        }

                        if (childnode.Name == "password")
                        {
                            doctor.ChangePassword(childnode.InnerText);
                        }

                        if (childnode.Name == "specialization")
                        {
                            doctor.ChangeSpecialization(childnode.InnerText);
                        }
                    }
                    doctors.Add(doctor);
                }
            }
            return doctors;
        }
        public void AddNewDoctor(Doctor doctor)
        {
            XmlElement doctorElem = XDoc.CreateElement("doctor");

            XmlAttribute loginAttr = XDoc.CreateAttribute("login");

            XmlElement nameElem = XDoc.CreateElement("name");
            XmlElement secondNameElem = XDoc.CreateElement("secondName");
            XmlElement surnameElem = XDoc.CreateElement("surname");
            XmlElement passwordElem = XDoc.CreateElement("password");
            XmlElement specializationElem = XDoc.CreateElement("specialization");


            XmlText nameText = XDoc.CreateTextNode(doctor.GetName());
            XmlText secondNameText = XDoc.CreateTextNode(doctor.GetSecondName());
            XmlText surnameText = XDoc.CreateTextNode(doctor.GetSurname());
            XmlText loginText = XDoc.CreateTextNode(doctor.GetLogin());
            XmlText passwordText = XDoc.CreateTextNode(doctor.GetPassword());
            XmlText specializationText = XDoc.CreateTextNode(doctor.GetSpecialization());

            loginAttr.AppendChild(loginText);
            nameElem.AppendChild(nameText);
            secondNameElem.AppendChild(secondNameText);
            surnameElem.AppendChild(surnameText);
            passwordElem.AppendChild(passwordText);
            specializationElem.AppendChild(specializationText);


            doctorElem.Attributes.Append(loginAttr);

            doctorElem.AppendChild(nameElem);
            doctorElem.AppendChild(secondNameElem);
            doctorElem.AppendChild(surnameElem);
            doctorElem.AppendChild(passwordElem);
            doctorElem.AppendChild(specializationElem);


            XRoot.AppendChild(doctorElem);

            XDoc.Save("doctors.xml");
        }

        public bool IsLoginContains(string login)
        {
            foreach (XmlElement xnode in XRoot)
            {
                XmlNode attr = xnode.Attributes.GetNamedItem("login");
                if (attr.Value == login)
                {
                    return true;
                }
            }
            return false;
        }

        public Doctor GetDoctor(string login)
        {
            Doctor doctor = new Doctor();
            foreach (XmlElement xnode in XRoot)
            {
                XmlNode attr = xnode.Attributes.GetNamedItem("login");
                if (attr.Value == login)
                {
                    doctor.ChangeLogin(login);
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "name")
                        {
                            doctor.ChangeName(childnode.InnerText);
                        }
                        if (childnode.Name == "secondName")
                        {
                            doctor.ChangeSecondName(childnode.InnerText);
                        }

                        if (childnode.Name == "surname")
                        {
                            doctor.ChangeSurname(childnode.InnerText);
                        }

                        if (childnode.Name == "password")
                        {
                            doctor.ChangePassword(childnode.InnerText);
                        }

                        if (childnode.Name == "specialization")
                        {
                            doctor.ChangeSpecialization(childnode.InnerText);
                        }
                    }
                    break;
                }
            }
            return doctor;
        }

        public string GetPassword(string login)
        {
            foreach (XmlElement xnode in XRoot)
            {
                XmlNode attr = xnode.Attributes.GetNamedItem("login");
                if (attr.Value == login)
                {
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "password")
                        {
                            return childnode.InnerText;
                        }
                    }
                }
            }
            return null;
        }
    }
}
