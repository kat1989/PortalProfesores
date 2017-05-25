using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web.Configuration;

namespace WebUI.Helpers
{
    public sealed class ReportCenterConfiguration : ConfigurationSection
    {
        private static ReportCenterConfiguration instance = null;
        public static ReportCenterConfiguration Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = (ReportCenterConfiguration)WebConfigurationManager.GetSection("reportCenter");
                }
                return instance;
            }
        }

        // Declare the reports collection property using the 
        // ConfigurationCollectionAttribute. 
        // This allows to build a nested section that contains 
        // a collection of elements.
        [ConfigurationProperty("reports", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ReportCollection),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public ReportCollection Reports
        {
            get
            {
                ReportCollection reportCollection = (ReportCollection)base["reports"];
                return reportCollection;
            }
        }
    }

    public class ReportElement : ConfigurationElement
    {
        [ConfigurationProperty("id", IsRequired = true)]
        public string Id
        {
            get { return (string)base["id"]; }
            set { base["id"] = value; }
        }

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("visualization", IsRequired = true)]
        public string Visualization
        {
            get { return (string)base["visualization"]; }
            set { base["visualization"] = value; }
        }
        [ConfigurationProperty("direccion", IsRequired = true)]
        public string Direccion
        {
            get { return (string)base["direccion"]; }
            set { base["direccion"] = value; }
        }
    }

    public class ReportCollection : ConfigurationElementCollection
    {
        public ReportCollection()
        {
            ReportElement report = (ReportElement)CreateNewElement();
            Add(report);
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ReportElement();
        }

        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((ReportElement)element).Id;
        }

        public ReportElement this[int index]
        {
            get
            {
                return (ReportElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        new public ReportElement this[string Name]
        {
            get
            {
                return (ReportElement)BaseGet(Name);
            }
        }

        public int IndexOf(ReportElement report)
        {
            return BaseIndexOf(report);
        }

        public void Add(ReportElement report)
        {
            BaseAdd(report);
        }
        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        public void Remove(ReportElement report)
        {
            if (BaseIndexOf(report) >= 0)
                BaseRemove(report.Name);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void Clear()
        {
            BaseClear();
        }
    }
}
