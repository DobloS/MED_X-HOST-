using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MED_X
{
    internal class XMLpatient
    {
        private XmlDocument XDoc = new XmlDocument();
        private XmlElement XRoot;

        public XMLpatient()
        {
            XDoc.Load("patients.xml");
            XRoot = XDoc.DocumentElement;
        }

        public List<Patient> GetAllPatients()
        {
            var patients = new List<Patient>();

            if (XRoot != null)
            {
                foreach (XmlElement xnode in XRoot)
                {
                    Patient patient = new Patient();
                    XmlNode attr = xnode.Attributes.GetNamedItem("snils");
                    patient.ChangeSnils(attr.Value);

                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "firstName")
                        {
                            patient.ChangeFirstName(childnode.InnerText);
                        }
                        if (childnode.Name == "secondName")
                        {
                            patient.ChangeSecondName(childnode.InnerText);
                        }
                        if (childnode.Name == "thirdName")
                        {
                            patient.ChangeThirdName(childnode.InnerText);
                        }
                        if (childnode.Name == "age")
                        {
                            patient.ChangeAge(int.Parse(childnode.InnerText));
                        }
                        if (childnode.Name == "policyNumber")
                        {
                            patient.ChangePolicyNumber(childnode.InnerText);
                        }
                        if (childnode.Name == "password")
                        {
                            patient.ChangeSnils(childnode.InnerText);
                        }
                    }
                    patients.Add(patient);
                }
            }
            return patients;
        }
        public void AddNewPatient(Patient patient)
        {
            XmlElement patientElem = XDoc.CreateElement("patient");

            XmlAttribute snilsAttr = XDoc.CreateAttribute("snils");

            XmlElement nameElem = XDoc.CreateElement("name");
            XmlElement secondNameElem = XDoc.CreateElement("secondName");
            XmlElement surnameElem = XDoc.CreateElement("surname");
            XmlElement ageElem = XDoc.CreateElement("age");
            XmlElement passwordElem = XDoc.CreateElement("password");
            XmlElement policyNumberElem = XDoc.CreateElement("policyNumber");


            XmlText nameText = XDoc.CreateTextNode(patient.GetFirstName());
            XmlText secondNameText = XDoc.CreateTextNode(patient.GetSecondName());
            XmlText surnameText = XDoc.CreateTextNode(patient.GetThirdName());
            XmlText ageText = XDoc.CreateTextNode(patient.GetAge().ToString());
            XmlText passwordText = XDoc.CreateTextNode(patient.GetPassword());
            XmlText policyNumberText = XDoc.CreateTextNode(patient.GetPolicyNumber());
            XmlText snilsText = XDoc.CreateTextNode(patient.GetSnils());

            nameElem.AppendChild(nameText);
            secondNameElem.AppendChild(secondNameText);
            surnameElem.AppendChild(surnameText);
            ageElem.AppendChild(ageText);
            passwordElem.AppendChild(passwordText);
            policyNumberElem.AppendChild(policyNumberText);
            snilsAttr.AppendChild(snilsText);


            patientElem.Attributes.Append(snilsAttr);

            patientElem.AppendChild(nameElem);
            patientElem.AppendChild(secondNameElem);
            patientElem.AppendChild(surnameElem);
            patientElem.AppendChild(ageElem);
            patientElem.AppendChild(passwordElem);
            patientElem.AppendChild(policyNumberElem);


            XRoot.AppendChild(patientElem);

            XDoc.Save("patients.xml");
        }

        public bool IsSnilsContains(string snils)
        {
            foreach (XmlElement xnode in XRoot)
            {
                XmlNode attr = xnode.Attributes.GetNamedItem("snils");
                if (attr.Value == snils)
                {
                    return true;
                }
            }
            return false;
        }

        public Patient GetPatient(string snils)
        {
            Patient patient = new Patient();
            foreach (XmlElement xnode in XRoot)
            {
                XmlNode attr = xnode.Attributes.GetNamedItem("snils");
                if (attr.Value == snils)
                {
                    patient.ChangeSnils(snils);
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "name")
                        {
                            patient.ChangeFirstName(childnode.InnerText);
                        }
                        if (childnode.Name == "secondName")
                        {
                            patient.ChangeSecondName(childnode.InnerText);
                        }

                        if (childnode.Name == "surname")
                        {
                            patient.ChangeThirdName(childnode.InnerText);
                        }

                        if (childnode.Name == "age")
                        {
                            patient.ChangeAge(int.Parse(childnode.InnerText));
                        }
                        if (childnode.Name == "password")
                        {
                            patient.ChangePassword(childnode.InnerText);
                        }
                        if (childnode.Name == "policyNumber")
                        {
                            patient.ChangePolicyNumber(childnode.InnerText);
                        }
                    }
                    break;
                }
            }
            return patient;
        }

        public string GetPassword(string snils)
        {
            foreach (XmlElement xnode in XRoot)
            {
                XmlNode attr = xnode.Attributes.GetNamedItem("snils");
                if (attr.Value == snils)
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
