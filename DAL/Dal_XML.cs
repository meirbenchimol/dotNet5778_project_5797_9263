using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;
using BE;
using static DS.DataSource;


namespace DAL
{
    class Dal_XML : Idal
    {

        private readonly string childPath = @"ChildXML.xml";

        private readonly string contractPath = @"ContractXML.xml";

        private readonly string motherPath = @"MotherXML.xml";

        private readonly string nannyPath = @"NannyXML.xml";





        private XElement ChildRoot;

        private XElement ContractRoot;

        private XElement MotherRoot;

        private XElement NannyRoot;

        //XElement NannyRoot;
        //string nannyPath = @"nannyXml.xml";


        //XElement MotherRoot;
        //string motherPath = @"motherXml.xml";


        //XElement ChildRoot;
        //string childPath = @"childXml.xml";

        //XElement ContractRoot;
        //string contractPath = @"contractXml.xml";

        public Dal_XML()
        {
            DS.DataSource myDataSource = new DS.DataSource();

            if (!File.Exists(nannyPath)||!File.Exists(motherPath))
                CreateFiles();
            else
                LoadData();
        }

        private void CreateFiles()
        {
            NannyRoot = new XElement ("Nanny");
            NannyRoot.Save(nannyPath);

            MotherRoot = new XElement("Mother");
            MotherRoot.Save(motherPath);

            ChildRoot = new XElement("Child");
            ChildRoot.Save(childPath);

            ContractRoot = new XElement("Contract");
            ContractRoot.Save(contractPath);



            //  ChildSerializer(DataSource.Childs,childsPath);

            ContractSerializer(ContractList, contractPath);

            MotherSerializer(MotherList, motherPath);

            NanniesSerializer(NannyList, nannyPath);

        }

        public bool FileExist()

        {

            if (!File.Exists(motherPath) || !File.Exists(nannyPath))

                return false;

            return true;

        }


        private void LoadData()
        {
            try
            {
                //NannyRoot = XElement.Load(nannyPath);
                //MotherRoot = XElement.Load(motherPath);
                //ChildRoot = XElement.Load(childPath);
                //ContractRoot = XElement.Load(contractPath);


                NannyDeserializer(nannyPath);



                MotherDeserializer(motherPath);



                ChildRoot = XElement.Load(childPath);

                //ChildDeserializer(childsPath);



                ContractDeserializer(contractPath);
            }

            catch
            {
                throw new Exception("File upload problem");
            }
        }


        //#region Converter
        //XElement ConvertNanny(Nanny nanny)
        //{
        //    XElement nannyElement = new XElement("nanny");

        //    foreach (PropertyInfo item in typeof(Nanny).GetProperties())
        //        nannyElement.Add
        //            (
        //            new XElement(item.Name, item.GetValue(nanny, null).ToString())
        //            );

        //    return nannyElement;
        //}
        //Nanny ConvertNanny(XElement element)
        //{
        //    Nanny nanny = new Nanny(0);

        //    foreach (PropertyInfo item in typeof(Nanny).GetProperties())
        //    {
        //        TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
        //        object convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);

        //        if (item.CanWrite)
        //            item.SetValue(nanny, convertValue);
        //    }

        //    return nanny;
        //}


        //XElement ConvertMother(Mother mom)
        //{
        //    XElement motherElement = new XElement("mother");

        //    foreach (PropertyInfo item in typeof(Mother).GetProperties())
        //        motherElement.Add
        //            (
        //            new XElement(item.Name, item.GetValue(mom, null).ToString())
        //            );

        //    return motherElement;
        //}

        //Mother ConvertMother(XElement element)
        //{
        //    Mother mom = new Mother(0);

        //    foreach (PropertyInfo item in typeof(Mother).GetProperties())
        //    {
        //        TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
        //        object convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);

        //        if (item.CanWrite)
        //            item.SetValue(mom, convertValue);
        //    }

        //    return mom;
        //}


        //XElement ConvertChild(Child child)
        //{
        //    XElement childElement = new XElement("child");

        //    foreach (PropertyInfo item in typeof(Child).GetProperties())
        //        childElement.Add
        //            (
        //            new XElement(item.Name, item.GetValue(child, null).ToString())
        //            );

        //    return childElement;
        //}

        //Child ConvertChild(XElement element)
        //{
        //    Child child = new Child(0, 0);

        //    foreach (PropertyInfo item in typeof(Child).GetProperties())
        //    {
        //        TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
        //        object convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);

        //        if (item.CanWrite)
        //            item.SetValue(child, convertValue);
        //    }

        //    return child;
        //}


        //XElement ConvertContract(Contract contract)
        //{
        //    XElement contractElement = new XElement("contract");

        //    foreach (PropertyInfo item in typeof(Contract).GetProperties())
        //        contractElement.Add
        //            (
        //            new XElement(item.Name, item.GetValue(contract, null).ToString())
        //            );

        //    return contractElement;
        //}

        //Contract ConvertContract(XElement element)
        //{
        //    Contract contract = new Contract(0, 0, 0);

        //    foreach (PropertyInfo item in typeof(Contract).GetProperties())
        //    {
        //        TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
        //        object convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);

        //        if (item.CanWrite)
        //            item.SetValue(contract, convertValue);
        //    }

        //    return contract;
        //}
        //#endregion

        //#region Nanny
        //public void AddNanny(Nanny nanny)
        //{
        //    Nanny myNanny = GetNanny(nanny.TeoudatZeout);
        //    if (myNanny != null)
        //        throw new Exception("Nanny with the same id already exists...");


        //    NannyRoot.Add(ConvertNanny(nanny));

        //    NannyRoot.Save(nannyPath);


        //}

        //public bool DeleteNanny(int teouatZeout)
        //{
        //    XElement toRemove = (from item in NannyRoot.Elements()
        //                         where int.Parse(item.Element("TeouatZeout").Value) == teouatZeout
        //                         select item).FirstOrDefault();

        //    if (toRemove == null)
        //        throw new Exception("Nanny with the same id not found...");

        //    toRemove.Remove();

        //    NannyRoot.Save(nannyPath);
        //    return true;
        //}
        //public void UpdateNanny(Nanny nanny)
        //{
        //    XElement toUpdate = (from item in NannyRoot.Elements()
        //                         where int.Parse(item.Element("TeouatZeout").Value) == nanny.TeoudatZeout
        //                         select item).FirstOrDefault();

        //    if (toUpdate == null)
        //        throw new Exception("Nanny with the same id not found...");

        //    foreach (PropertyInfo item in typeof(Nanny).GetProperties())
        //        toUpdate.Element(item.Name).SetValue(item.GetValue(nanny).ToString());

        //    NannyRoot.Save(nannyPath);
        //}
        //public Nanny GetNanny(int teoudatZeout)
        //{
        //    XElement stu = null;

        //    try
        //    {
        //        stu = (from item in NannyRoot.Elements()
        //               where int.Parse(item.Element("TeoudatZeout").Value) == teoudatZeout
        //               select item).FirstOrDefault();
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }

        //    if (stu == null)
        //        return null;

        //    return ConvertNanny(stu);
        //}
        //public IEnumerable<Nanny> GetAllNanny(Func<Nanny, bool> predicate = null)
        //{

        //    if (predicate == null)
        //    {
        //        return from item in NannyRoot.Elements()
        //               select ConvertNanny(item);
        //    }

        //    return from item in NannyRoot.Elements()
        //           let s = ConvertNanny(item)
        //           where predicate(s)
        //           select s;
        //}
        //#endregion

        //#region Mother
        //public void AddMother(Mother mother)
        //{
        //    Mother myMother = GetMother(mother.TeoudatZeout);
        //    if (myMother != null)
        //        throw new Exception("Mother with the same id already exists...");


        //    MotherRoot.Add(ConvertMother(mother));

        //    MotherRoot.Save(motherPath);


        //}

        //public bool DeleteMother(int teouatZeout)
        //{
        //    XElement toRemove = (from item in MotherRoot.Elements()
        //                         where int.Parse(item.Element("TeouatZeout").Value) == teouatZeout
        //                         select item).FirstOrDefault();

        //    if (toRemove == null)
        //        throw new Exception("Mother with the same id not found...");

        //    toRemove.Remove();

        //    MotherRoot.Save(motherPath);
        //    return true;
        //}
        //public void UpdateMother(Mother mother)
        //{
        //    XElement toUpdate = (from item in MotherRoot.Elements()
        //                         where int.Parse(item.Element("TeouatZeout").Value) == mother.TeoudatZeout
        //                         select item).FirstOrDefault();

        //    if (toUpdate == null)
        //        throw new Exception("Mother with the same id not found...");

        //    foreach (PropertyInfo item in typeof(Mother).GetProperties())
        //        toUpdate.Element(item.Name).SetValue(item.GetValue(mother).ToString());

        //    MotherRoot.Save(motherPath);
        //}
        //public Mother GetMother(int teoudatZeout)
        //{
        //    XElement stu = null;

        //    try
        //    {
        //        stu = (from item in MotherRoot.Elements()
        //               where int.Parse(item.Element("TeoudatZeout").Value) == teoudatZeout
        //               select item).FirstOrDefault();
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }

        //    if (stu == null)
        //        return null;

        //    return ConvertMother(stu);
        //}
        //public IEnumerable<Mother> GetAllMother(Func<Mother, bool> predicate = null)
        //{

        //    if (predicate == null)
        //    {
        //        return from item in MotherRoot.Elements()
        //               select ConvertMother(item);
        //    }

        //    return from item in MotherRoot.Elements()
        //           let s = ConvertMother(item)
        //           where predicate(s)
        //           select s;
        //}
        //#endregion

        //#region Child
        //public void AddChild(Child child)
        //{
        //    Child myChild = GetChild(child.TeoudatZeout);
        //    if (myChild != null)
        //        throw new Exception("children with the same id already exists...");


        //    ChildRoot.Add(ConvertChild(child));

        //    ChildRoot.Save(childPath);


        //}

        //public bool DeleteChild(int teouatZeout)
        //{
        //    XElement toRemove = (from item in ChildRoot.Elements()
        //                         where int.Parse(item.Element("TeouatZeout").Value) == teouatZeout
        //                         select item).FirstOrDefault();

        //    if (toRemove == null)
        //        throw new Exception("Child with the same id not found...");

        //    toRemove.Remove();

        //    ChildRoot.Save(childPath);
        //    return true;
        //}
        //public void UpdateChild(Child child)
        //{
        //    XElement toUpdate = (from item in ChildRoot.Elements()
        //                         where int.Parse(item.Element("TeouatZeout").Value) == child.TeoudatZeout
        //                         select item).FirstOrDefault();

        //    if (toUpdate == null)
        //        throw new Exception("Child with the same id not found...");

        //    foreach (PropertyInfo item in typeof(Child).GetProperties())
        //        toUpdate.Element(item.Name).SetValue(item.GetValue(child).ToString());

        //    ChildRoot.Save(childPath);
        //}
        //public Child GetChild(int teoudatZeout)
        //{
        //    XElement stu = null;

        //    try
        //    {
        //        stu = (from item in ChildRoot.Elements()
        //               where int.Parse(item.Element("TeoudatZeout").Value) == teoudatZeout
        //               select item).FirstOrDefault();
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }

        //    if (stu == null)
        //        return null;

        //    return ConvertChild(stu);
        //}
        //public IEnumerable<Child> GetAllChild(Func<Child, bool> predicate = null)
        //{

        //    if (predicate == null)
        //    {
        //        return from item in ChildRoot.Elements()
        //               select ConvertChild(item);
        //    }

        //    return from item in ChildRoot.Elements()
        //           let s = ConvertChild(item)
        //           where predicate(s)
        //           select s;
        //}
        //#endregion

        //#region Contract
        //public void AddContract(Contract contract)
        //{
        //    Contract myContract = GetContract(contract.ContractNumber);
        //    if (myContract != null)
        //        throw new Exception("Contract with the same number already exists...");


        //    ContractRoot.Add(ConvertContract(contract));

        //    ContractRoot.Save(contractPath);


        //}

        //public bool DeleteContract(int contractNumber)
        //{
        //    XElement toRemove = (from item in ContractRoot.Elements()
        //                         where int.Parse(item.Element("ContractNumber").Value) == contractNumber
        //                         select item).FirstOrDefault();

        //    if (toRemove == null)
        //        throw new Exception("Contract with the same id not found...");

        //    toRemove.Remove();

        //    ContractRoot.Save(contractPath);
        //    return true;
        //}
        //public void UpdateContract(Contract contract)
        //{
        //    XElement toUpdate = (from item in ContractRoot.Elements()
        //                         where int.Parse(item.Element("ContractNumber").Value) == contract.ContractNumber
        //                         select item).FirstOrDefault();

        //    if (toUpdate == null)
        //        throw new Exception("Nanny with the same id not found...");

        //    foreach (PropertyInfo item in typeof(Contract).GetProperties())
        //        toUpdate.Element(item.Name).SetValue(item.GetValue(contract).ToString());

        //    ContractRoot.Save(contractPath);
        //}
        //public Contract GetContract(int contractNumber)
        //{
        //    XElement stu = null;

        //    try
        //    {
        //        stu = (from item in ContractRoot.Elements()
        //               where int.Parse(item.Element("ContractNumber").Value) == contractNumber
        //               select item).FirstOrDefault();
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }

        //    if (stu == null)
        //        return null;

        //    return ConvertContract(stu);
        //}
        //public IEnumerable<Contract> GetAllContract(Func<Contract, bool> predicate = null)
        //{

        //    if (predicate == null)
        //    {
        //        return from item in ContractRoot.Elements()
        //               select ConvertContract(item);
        //    }

        //    return from item in ContractRoot.Elements()
        //           let s = ConvertContract(item)
        //           where predicate(s)
        //           select s;
        //}
        //#endregion



        private static void NanniesSerializer(IEnumerable<Nanny> list, string path)

        {

            try

            {

                // List to XML

                XmlSerializerNamespaces n = new XmlSerializerNamespaces();



                FileStream file = new FileStream(path, FileMode.Create);

                XmlSerializer xmlSerializer = new XmlSerializer(list.GetType());

                xmlSerializer.Serialize(file, list);

                file.Close();

            }

            catch (Exception e)

            {

                throw new Exception("Error saving the nannies", e);

            }

        }



        private static void NannyDeserializer(string path)

        {

            try

            {

                // XML to List

                XmlSerializer nannyDeserializer = new XmlSerializer(typeof(List<Nanny>));

                FileStream nannyFile = new FileStream(path, FileMode.Open);

                NannyList = (List<Nanny>)nannyDeserializer.Deserialize(nannyFile);

                nannyFile.Close();

            }

            catch (Exception e)

            {

                throw new Exception("Error initializing the nannies", e);

            }

        }



        private static void MotherSerializer(IEnumerable<Mother> list, string path)

        {

            try

            {

                // List to XML

                FileStream file = new FileStream(path, FileMode.Create);

                XmlSerializer xmlSerializer = new XmlSerializer(list.GetType());

                xmlSerializer.Serialize(file, list);

                file.Close();

            }

            catch (Exception e)

            {

                throw new Exception("Error saving the mothers", e);

            }

        }



        private static void MotherDeserializer(string path)

        {

            try

            {

                // XML to List

                XmlSerializer motherDeserializer = new XmlSerializer(typeof(List<Mother>));

                FileStream motherFile = new FileStream(path, FileMode.Open);

                MotherList = (List<Mother>)motherDeserializer.Deserialize(motherFile);

                motherFile.Close();

            }

            catch (Exception e)

            {

                throw new Exception("Error initializing the mothers", e);

            }

        }



        /* private static void ChildSerializer(IEnumerable<Child> list, string path)

         {

             try

             {

                  List to XML

                 FileStream file = new FileStream(path, FileMode.Create);

                 XmlSerializer xmlSerializer = new XmlSerializer(list.GetType());

                 xmlSerializer.Serialize(file, list);

                 file.Close();

             }

             catch (Exception e)

             {

                 throw new Exception("Error saving the child", e);

             }

         }



         private static void ChildDeserializer(string path)

         {

             try

             {

                  XML to List

                 XmlSerializer childDeserializer = new XmlSerializer(typeof(List<Child>));

                 FileStream childFile = new FileStream(path, FileMode.Open);

                 DataSource.Childs = (List<Child>)childDeserializer.Deserialize(childFile);

                 childFile.Close();

             }

             catch (Exception e)

             {

                 throw new Exception("Error initializing the childs", e);

             }

         }*/



        private static void ContractSerializer(IEnumerable<Contract> list, string path)

        {

            try

            {

                //List to XML

               FileStream file = new FileStream(path, FileMode.Create);

                XmlSerializer xmlSerializer = new XmlSerializer(list.GetType());

                xmlSerializer.Serialize(file, list);

                file.Close();

            }

            catch (Exception e)

            {

                throw new Exception("Error saving the contracts", e);

            }

        }



        private static void ContractDeserializer(string path)

        {

            try

            {

              //  XML to List

               XmlSerializer contractDeserializer = new XmlSerializer(typeof(List<Contract>));

                FileStream contractFile = new FileStream(path, FileMode.Open);

                ContractList = (List<Contract>)contractDeserializer.Deserialize(contractFile);

                contractFile.Close();

            }

            catch (Exception e)

            {

                throw new Exception("Error initializing the contracts", e);

            }

        }





        #region NannyFunction



        // <summary>

       //     Ajoute une nanny a la data source

        //     Throw une exception de type DuplicateNameException si elle existe deja

        // </summary>

        // <param name = "nanny" ></ param >

        public void AddNanny(Nanny nanny)

        {

            if (GetNanny(nanny.TeoudatZeout) == null)

            {

                NannyList.Add(nanny);

                NanniesSerializer(GetAllNanny(null), nannyPath);

            }

            else

            {

                throw new DuplicateNameException("This nanny IdNumber number already exist");

            }

        }
        
       
        public bool DeleteNanny(int teoudatZeout)
        {
            if (!NannyList.Exists(x => x.TeoudatZeout == teoudatZeout))
                throw new Exception("this nanny doesn't exist !");

            NannyList.Remove(NannyList.Find(n => n.TeoudatZeout == teoudatZeout));
            ContractList.Remove(ContractList.Find(n => n.TeoudatZeoutNanny == teoudatZeout));

            NanniesSerializer(GetAllNanny(null), nannyPath);
            ContractSerializer(GetAllContract(null), contractPath);

            return NannyList.Remove(NannyList.Find(n => n.TeoudatZeout == teoudatZeout));

        }


        public void UpdateNanny(Nanny nanny)

        {

            Nanny toUpdate = GetNanny(nanny.TeoudatZeout);

            foreach (PropertyInfo property in toUpdate.GetType().GetProperties())



                if (property.GetValue(toUpdate) !=

                    nanny.GetType().GetProperty(property.Name).GetValue(nanny))

                    toUpdate.GetType().GetProperty(property.Name)

                            .SetValue(toUpdate, property.GetValue(nanny));



            NanniesSerializer(GetAllNanny(null), nannyPath);

        }


        public Nanny GetNanny(int teoudatZeout)
        {

            return NannyList.FirstOrDefault(x => x.TeoudatZeout == teoudatZeout);

        }
        public IEnumerable<Nanny> GetAllNanny(Func<Nanny, bool> predicate = null)
        {
            if (predicate == null)
                return NannyList.AsEnumerable();
            return NannyList.Where(predicate);
        }


        #endregion



        #region MotherFunction

        public void AddMother(Mother mother)
        {
            if (MotherList.Exists(x => x.TeoudatZeout == mother.TeoudatZeout))
                throw new Exception("this Mom already exist !");
            MotherList.Add(mother);

            MotherSerializer(GetAllMother(null), motherPath);

        }
        public bool DeleteMother(int teoudatZeout)
        {
            if (!MotherList.Exists(x => x.TeoudatZeout == teoudatZeout))
                throw new Exception("this mom not found !");
            MotherList.Remove(MotherList.Find(x => x.TeoudatZeout == teoudatZeout));

            MotherSerializer(GetAllMother(null), motherPath);


            return MotherList.Remove(MotherList.Find(x => x.TeoudatZeout == teoudatZeout));
        }
        public void UpdateMother(Mother mother)

        {

            Mother toUpdate = GetMother(mother.TeoudatZeout);

            foreach (PropertyInfo property in toUpdate.GetType().GetProperties())



                if (property.GetValue(toUpdate) !=

                    mother.GetType().GetProperty(property.Name).GetValue(mother))

                    toUpdate.GetType().GetProperty(property.Name)

                            .SetValue(toUpdate, property.GetValue(mother));

            MotherSerializer(GetAllMother(null), motherPath);

        }
    
        public Mother GetMother(int teoudatZeout)
        {

            return MotherList.FirstOrDefault(x => x.TeoudatZeout == teoudatZeout);

        }
        public IEnumerable<Mother> GetAllMother(Func<Mother, bool> predicate = null)
        {
            if (predicate == null)
                return MotherList.AsEnumerable();
            return MotherList.Where(predicate);
        }

        

        #endregion

        

        #region Childs Functions



        public void AddChild(Child child)

        {

            try

            {

                if (GetChild(child.TeoudatZeout) == null)

                {

                    XElement teoudatZeout = new XElement("idNumber", child.TeoudatZeout);

                    XElement firstname = new XElement("firstname", child.Firstname);

                    XElement teoudatZeoutMom = new XElement("teoudatZeoutMom", child.TeoudatZeoutMom);

                    XElement genderChild = new XElement("genderChild", child.GenderChild);

                    XElement birthday = new XElement("birthday", child.Birthday);

                    XElement specialNeeds = new XElement("specialsNeeds", child.SpecialNeeds);

                    XElement specialNeed = new XElement("specialNeed", child.SpecialNeed);



                    ChildRoot.Add(new XElement("Child", teoudatZeout, firstname, teoudatZeoutMom, birthday,genderChild,

                                                specialNeeds, specialNeed));

                    ChildRoot.Save(childPath);

                }

                else

                {

                    throw new Exception("This id already exist");

                }

            }

            catch (Exception e)

            {

                throw new Exception("DAL Error : Can't add this child", e);

            }

        }

        
        public bool DeleteChild(int teoudatZeout)

        {

            try

            {
                bool flag = false;
                Child child = GetChild(teoudatZeout);
                IEnumerable<XElement> xElements = ChildRoot.Elements();

                Child childTodel = new Child(0,0);



                foreach (XElement item in xElements)

                    if (int.Parse(item.Element("teoudatZeout").Value) == child.TeoudatZeout)
                    { 
                        item.Remove();
                        flag = true;
                    }


                ChildRoot.Save(childPath);
                return flag;

            }

            catch (Exception e)

            {

                throw new ArgumentException("DAL Error : Can't remove this child", e);

            }

        }



        public void UpdateChild(Child child)

        {

            try

            {

               

                DeleteChild(child.TeoudatZeout);

                AddChild(child);



                ChildRoot.Save(childPath);

            }

            catch (Exception e)

            {

                throw new ArgumentException("DAL Error : Can't update this child", e);

            }

        }



        public Child GetChild(int  teoudatZeout)

        {

            try

            {

                Child child = (from c in ChildRoot.Elements()

                               where Convert.ToInt64(c.Element("teoudatZeout").Value) == teoudatZeout

                               select new Child(0,0)
                               {

                                   TeoudatZeout = Convert.ToInt32(c.Element("teoudatZeout").Value),

                                   TeoudatZeoutMom = Convert.ToInt32(c.Element("teoudatZeoutMom").Value),

                                   Firstname = c.Element("firstname").Value,

                                   Birthday = Convert.ToDateTime(c.Element("birthday").Value),

                                   SpecialNeed = Convert.ToBoolean(c.Element("specialsNeed").Value),

                                   SpecialNeeds = c.Element("specialNeeds").Value

                               }).FirstOrDefault();

                return child;

            }

            catch (Exception e)

            {

                throw new Exception("DAL Error : Can't find the Child", e);

            }

        }
        public IEnumerable<Child> GetAllChild(Func<Child, bool> predicate = null)

    {

            try

            {

                IEnumerable<XElement> xElements = ChildRoot.Elements();

                List<Child> childsToReturn = new List<Child>();


                if (predicate == null)
                { 
                    foreach (XElement item in xElements)

                {

                    Child c = new Child(0,0);

                    c.TeoudatZeout = int.Parse(item.Element("teoudatZeout").Value);

                    c.TeoudatZeoutMom = int.Parse(item.Element("teoudatZeoutMom").Value);

                    c.Birthday = DateTime.Parse(item.Element("birthday").Value);

                    //c.GenderChild = Gender.Parse(item.Element("genderChild").Value);

                    c.Firstname = item.Element("firstname").Value;

                    c.SpecialNeed = bool.Parse(item.Element("specialsNeed").Value);

                    c.SpecialNeeds = item.Element("specialNeeds").Value;



                    childsToReturn.Add(c);

                }



                return childsToReturn;
                }
                else
                {
                    foreach (XElement item in xElements)

                    {

                        Child c = new Child(0, 0);

                        c.TeoudatZeout = int.Parse(item.Element("teoudatZeout").Value);

                        c.TeoudatZeoutMom = int.Parse(item.Element("teoudatZeoutMom").Value);

                        c.Birthday = DateTime.Parse(item.Element("birthday").Value);

                        //c.GenderChild = Gender.Parse(item.Element("genderChild").Value);

                        c.Firstname = item.Element("firstname").Value;

                        c.SpecialNeed = bool.Parse(item.Element("specialsNeed").Value);

                        c.SpecialNeeds = item.Element("specialNeeds").Value;



                        childsToReturn.Add(c);

                    }



                    return childsToReturn;
                }

            }

            catch (Exception e)

            {

                throw new Exception("DAL Error : Can't get the childs", e);

            }

        }


        #endregion



        #region ContractFunction



        public void AddContract(Contract contract)

        {

            if (GetContract(contract.ContractNumber) == null)

            {

                ContractList.Add(contract);

                ContractSerializer(GetAllContract(null), contractPath);

            }

            else

            {

                throw new DuplicateNameException("DAL Error : This contract ID number already exist");

            }

        }

        public bool DeleteContract(int contractNumber)
        {
            if (!ContractList.Exists(x => x.ContractNumber == contractNumber))
                throw new Exception(" this contract not found !");
            ContractList.Remove(ContractList.Find(x => x.ContractNumber == contractNumber));

            ContractSerializer(GetAllContract(null), contractPath);


            return ContractList.Remove(ContractList.Find(x => x.ContractNumber == contractNumber));

        }

      
        
        public void UpdateContract(Contract contract )

        {

            Contract toUpdate = GetContract(contract.ContractNumber);

            foreach (PropertyInfo property in toUpdate.GetType().GetProperties())



                if (property.GetValue(toUpdate) !=

                    contract.GetType().GetProperty(property.Name).GetValue(contract))

                    toUpdate.GetType().GetProperty(property.Name)

                            .SetValue(toUpdate, property.GetValue(contract));



            ContractSerializer(GetAllContract(null), contractPath);

        }
        public Contract GetContract(int contractNumber)
        {

            return ContractList.FirstOrDefault(x => x.ContractNumber == contractNumber);

        }
        public IEnumerable<Contract> GetAllContract(Func<Contract, bool> predicate = null)
        {
            if (predicate == null)
                return ContractList.AsEnumerable();
            return ContractList.Where(predicate);

        }
        #endregion

        
    }
}
