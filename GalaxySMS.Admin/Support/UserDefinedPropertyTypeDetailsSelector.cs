using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GalaxySMS.Client.Entities;

namespace GalaxySMS.Admin
{
    public class UserDefinedPropertyTypeDetailsSelector : DataTemplateSelector
    {
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            if (item is UserDefinedProperty)
            {
                var udp = item as UserDefinedProperty;
                if (udp.UserDefinedTextPropertyRules != null )
                    return UserDefinedTextPropertyRulesTemplate;

                if (udp.UserDefinedBooleanPropertyRules != null)
                    return UserDefinedBooleanPropertyRulesTemplate;

                if (udp.UserDefinedNumberPropertyRules != null)
                    return UserDefinedNumberPropertyRulesTemplate;

                if (udp.UserDefinedDatePropertyRules != null)
                    return UserDefinedDatePropertyRulesTemplate;

                if (udp.UserDefinedListPropertyRules != null)
                    return UserDefinedListPropertyRulesTemplate;
            }
            return null;
        }

        public DataTemplate UserDefinedTextPropertyRulesTemplate { get; set; }
        public DataTemplate UserDefinedNumberPropertyRulesTemplate { get; set; }
        public DataTemplate UserDefinedListPropertyRulesTemplate { get; set; }
        public DataTemplate UserDefinedDatePropertyRulesTemplate { get; set; }
        public DataTemplate UserDefinedBooleanPropertyRulesTemplate { get; set; }

    }
}
