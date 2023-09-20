using System.Collections.Generic;
using GalaxySMS.Client.Entities;
using GCS.Core.Common.UI.Core;

namespace GalaxySMS.Client.Contracts.ViewModelContracts
{
    public interface ISupportsUserEntitySelection
    {
        UserSessionToken UserSessionToken { get; }
        string EntityAlias { get; set; }
        string EntityAliasPlural { get; set; }
        string SelectEntityHeaderText { get; set; }
        string SelectEntityHeaderToolTip { get; set; }
        ICollection<UserEntitySelect> UserEntitiesSelectionList { get; }
        DelegateCommand<UserEntitySelect> EntityMapChecked { get; set; }
        void OnEntityMapChecked(UserEntitySelect obj);
    }
}
