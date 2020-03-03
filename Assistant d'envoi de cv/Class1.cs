using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Assistant_d_envoi_de_cv
{
    class TheSetupXMLFile
    {
        private static TheSetupXMLFile instance;

        public string mailUser = "";
        public string userName = "";
        public string userPwd = "";
        public int selectionProfil = 0;
        public string smtp = "stmp.gmail.com";
        public string port = "587";
      

        public List<Profile> profils = new List<Profile>();


        public TheSetupXMLFile()
        {


        }

        public static TheSetupXMLFile getInstance()
        {
            if (instance == null)
            {
                instance = new TheSetupXMLFile();
            }
            return instance;
        }

        public void readXML()
        {
            profils.Clear();
            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                
                xmlDoc.Load("setup.xml");

                XmlNode node = xmlDoc.SelectSingleNode("/setup");
                mailUser = node.Attributes["mail"].Value;
                userName = node.Attributes["identifiant"].Value;
                userPwd = node.Attributes["mot-de-passe"].Value;
                smtp = node.Attributes["serveur-smtp"].Value;
                port = node.Attributes["port"].Value;
                

                XmlNode profilsN = xmlDoc.SelectSingleNode("/setup/Profils");
                if (profilsN != null)
                {
                    if (profilsN.HasChildNodes)
                    {
                        for (int i = 0; i < profilsN.ChildNodes.Count; i++)
                        {
                            Profile p = new Profile();
                            p.profilName = profilsN.ChildNodes[i].Attributes["nom"].Value;
                            p.mailContent = profilsN.ChildNodes[i].Attributes["mail-contenu"].Value;
                            p.subject = profilsN.ChildNodes[i].Attributes["sujet"].Value;

                            for (int a = 0; a < profilsN.ChildNodes[i].ChildNodes.Count; a++)
                            {
                                p.filesPath.Add(profilsN.ChildNodes[i].ChildNodes[a].InnerText);                                
                            }

                            profils.Add(p);
                        }
                    }
                }

                    xmlDoc.Save("setup.xml");
            }
            catch (System.IO.FileNotFoundException)
            {
                // Si le fichier n'existe pas on le crée
                

                XmlWriter writer = XmlWriter.Create("setup.xml");
                writer.WriteStartDocument();

                writer.WriteStartElement("setup");
                writer.WriteAttributeString("mail", "exemple@gmail.com");
                writer.WriteAttributeString("identifiant", "");
                writer.WriteAttributeString("selection-profil", "");
                writer.WriteAttributeString("mot-de-passe", "");
                writer.WriteAttributeString("serveur-smtp", "smtp.gmail.com");
                writer.WriteAttributeString("port", "587");
                writer.WriteEndElement();

             
                writer.Flush();
             
                writer.Close();


                saveXML();

                //XmlWriter xmlWriter = XmlWriter.Create("setup.xml");
            }

        }

        public void saveXML()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("setup.xml");

            XmlNode node = xmlDoc.SelectSingleNode("/setup");
            node.Attributes["mail"].Value = mailUser;
            node.Attributes["identifiant"].Value = userName;
            node.Attributes["mot-de-passe"].Value = userPwd;
            node.Attributes["serveur-smtp"].Value = smtp;
            node.Attributes["port"].Value = port;
            node.Attributes["selection-profil"].Value = selectionProfil.ToString();
           
            XmlNode root = xmlDoc.DocumentElement;
            XmlNode profilsN = xmlDoc.SelectSingleNode("/setup/Profils");

            if(profilsN==null)
            {
                XmlElement elemp = xmlDoc.CreateElement("Profils");
                elemp.SetAttribute("content", "Profils");
                node.AppendChild(elemp);
            }

            for (var i = 0; i < profils.Count; i++) // Pour chaque profil
            {
                bool findInNode = false;

                if (profilsN.HasChildNodes) // On regarde dans les noeuds
                {
                    for (int a = 0; a < profilsN.ChildNodes.Count; a++)
                    {
                        // Si on trouve un noeud qui a le nom d'un profil 
                        if (profilsN.ChildNodes[a].Attributes["nom"].Value == profils[i].profilName)
                        {
                            if (profils[i].live == false)
                            {
                                profilsN.RemoveChild(profilsN.ChildNodes[a]);

                            }
                            else
                            {
                                profilsN.ChildNodes[a].Attributes["mail-contenu"].Value = profils[i].mailContent;
                                profilsN.ChildNodes[a].Attributes["sujet"].Value = profils[i].subject;

                                for (int z = 0; z < profils[i].filesPath.Count; z++)
                                {
                                    bool findPathInNode = false;

                                    for (int y = 0; y < profilsN.ChildNodes[a].ChildNodes.Count; y++)
                                    {

                                        if (profilsN.ChildNodes[a].ChildNodes[y].InnerText == profils[i].filesPath[z])
                                        {
                                            findPathInNode = true;
                                        }                                      

                                    }
                                    if (findPathInNode == false)
                                    {
                                        XmlElement fileE = xmlDoc.CreateElement("Fichier");
                                        fileE.InnerText = profils[i].filesPath[z];
                                        profilsN.ChildNodes[a].AppendChild(fileE);
                                    }

                                }
                              
                            }

                            findInNode = true;

                        }
                    }                   
                }
                // Il faut créer une boucle qui supprime les fichiers en trop 
                for (int a = 0; a < profilsN.ChildNodes.Count; a++)
                {
                    
                    for (int y = 0; y < profilsN.ChildNodes[a].ChildNodes.Count; y++)
                    {
                        bool finded = false;

                        for (int z = 0; z < profils[i].filesPath.Count; z++)
                        {
                            if (profils[i].filesPath[z] == profilsN.ChildNodes[a].ChildNodes[y].InnerText)
                            {
                                finded = true;
                            }
                        }
                        if (finded != true)
                        {
                            profilsN.ChildNodes[a].RemoveChild(profilsN.ChildNodes[a].ChildNodes[y]);
                        }
                    }
                }

                // On trouve pas le noeud, on le crée.
                if (findInNode == false)
                {
                    XmlElement elem = xmlDoc.CreateElement("Profil");
                    elem.SetAttribute("nom", profils[i].profilName);
                    elem.SetAttribute("mail-contenu", profils[i].mailContent);
                    elem.SetAttribute("sujet", profils[i].subject);
                    profilsN.AppendChild(elem);

                    for (int z = 0; z < profils[i].filesPath.Count; z++)
                    {
                        XmlElement fileE = xmlDoc.CreateElement("Fichier");
                        fileE.InnerText = profils[i].filesPath[z];
                        elem.AppendChild(fileE);
                    }
                }
            }                      
            xmlDoc.Save("setup.xml");
        }

    }
   

}
