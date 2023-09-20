using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.Common.Constants;
using GalaxySMS.Common.Interfaces;

namespace GalaxySMS.Data.Support
{
    public class AccessGroupHelpers
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Validates the access group assignments. </summary>
        ///
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="accessGroups">         [in,out] The four access groups assigned to the person or profile. </param>
        /// <param name="allAccessGroups">      [in,out] A list of all access groups. </param>
        /// <param name="assignedAccessGroups"> [in,out] The collection of 4 IAccessGroupAssignment items. </param>
        ///=================================================================================================

        public static void ValidateAccessGroupAssignments(ref List<AccessGroup> accessGroups, ref IEnumerable<AccessGroup> allAccessGroups, ref List<IAccessGroupAssignment> assignedAccessGroups)
        {
            if( accessGroups.Count != assignedAccessGroups.Count)
                throw new Exception($"ValidateAccessGroupAssignments accessGroups.Count:{accessGroups.Count} != assignedAccessGroups.Count: {assignedAccessGroups.Count}");
            var ag1 = accessGroups[0];
            var ag2 = accessGroups[1];
            var ag3 = accessGroups[2];
            var ag4 = accessGroups[3];

            var pag1 = assignedAccessGroups[0];
            var pag2 = assignedAccessGroups[1];
            var pag3 = assignedAccessGroups[2];
            var pag4 = assignedAccessGroups[3];

            // if ag1 is extended, this is not permitted. 
            if (ag1 != null && ag1.AccessGroupNumber > Common.Constants.AccessGroupLimits.UnlimitedAccess)
            {
                throw new Exception($"{pag1.GetType().Name} with OrderNumber:{pag1.OrderNumber} cannot be configured as an extended access group ( # greater than {AccessGroupLimits.UnlimitedAccess } )");
                // See if it can be re-assigned to either 3 or 4 
                //if (ag1.AccessGroupNumber < Common.Constants.AccessGroupLimits.PersonalAccessGroup)
                //{   // if ag1 is extended but not the personal access group, then see if it can be reassigned to ag3
                //    if (ag3 != null && ag3.AccessGroupNumber <= Common.Constants.AccessGroupLimits.UnlimitedAccess)
                //    {   // if ag3 is not an extended group, swap with ag1
                //        var tempUid1 = ag1.AccessGroupUid;
                //        var tempUid3 = ag3.AccessGroupUid;
                //        pag1.AccessGroupUid = tempUid3;
                //        pag3.AccessGroupUid = tempUid1;
                //        var tempAg1 = AccessGroup.Clone(ag1);
                //        var tempAg3 = AccessGroup.Clone(ag3);
                //        ag1 = tempAg3;
                //        ag3 = tempAg1;
                //    }
                //    else
                //        throw new Exception($"{pag1.GetType().Name} with OrderNumber:{pag1.OrderNumber} cannot be configured as an extended access group");
                //}
                //else if (ag1.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.PersonalAccessGroup)
                //{  // if personal access group is assigned to Order # 1, see if it can be re-assigned to 4
                //    if (ag4 != null && ag4.AccessGroupNumber <= Common.Constants.AccessGroupLimits.UnlimitedAccess)
                //    {   // swap ag1 and ag4
                //        var tempUid1 = ag1.AccessGroupUid;
                //        var tempUid4 = ag4.AccessGroupUid;
                //        pag1.AccessGroupUid = tempUid4;
                //        pag4.AccessGroupUid = tempUid1;
                //    }
                //    else
                //        throw new Exception($"{pag1.GetType().Name} with OrderNumber:{pag1.OrderNumber} cannot be configured as a personal access group");
                //    // if it cannot be re-assigned, throw an exception
                //}
            }
            else
            {
                if (ag1 != null)
                {
                    pag1.AccessGroupUid = ag1.AccessGroupUid;
                }
            }
            // if ag2 is extended, this is not permitted. 
            if (ag2 != null && ag2.AccessGroupNumber > Common.Constants.AccessGroupLimits.UnlimitedAccess)
            {
                throw new Exception($"{pag2.GetType().Name} with OrderNumber:{pag2.OrderNumber} cannot be configured as an extended access group ( # greater than {AccessGroupLimits.UnlimitedAccess } )");
                //See if it can be re-assigned to either 3 or 4
                //if (ag2.AccessGroupNumber < Common.Constants.AccessGroupLimits.PersonalAccessGroup)
                //{   // if ag2 is extended but not the personal access group, then see if it can be reassigned to ag3
                //    if (ag3 != null && ag3.AccessGroupNumber <= Common.Constants.AccessGroupLimits.UnlimitedAccess)
                //    {   // if ag3 is not an extended group, swap with ag2
                //        var tempUid2 = ag2.AccessGroupUid;
                //        var tempUid3 = ag3.AccessGroupUid;
                //        pag2.AccessGroupUid = tempUid3;
                //        pag3.AccessGroupUid = tempUid2;
                //    }
                //    else
                //        throw new Exception($"{pag2.GetType().Name} with OrderNumber:{pag2.OrderNumber} cannot be configured as an extended access group");
                //}
                //else if (ag2.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.PersonalAccessGroup)
                //{  // if personal access group is assigned to Order # 2, see if it can be re-assigned to 4
                //    if (ag4 != null && ag4.AccessGroupNumber <= Common.Constants.AccessGroupLimits.UnlimitedAccess)
                //    {   // swap ag2 and ag4
                //        var tempUid2 = ag2.AccessGroupUid;
                //        var tempUid4 = ag4.AccessGroupUid;
                //        pag2.AccessGroupUid = tempUid4;
                //        pag4.AccessGroupUid = tempUid2;
                //    }
                //    else
                //        throw new Exception($"{pag2.GetType().Name} with OrderNumber:{pag2.OrderNumber} cannot be configured as a personal access group");
                //    // if it cannot be re-assigned, throw an exception
                //}
            }
            else
            {
                if (ag2 != null)
                {
                    pag2.AccessGroupUid = ag2.AccessGroupUid;
                }
            }

            if (ag3 != null && ag3.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.PersonalAccessGroup)
            {  // if personal access group is assigned to Order # 3
                throw new Exception($"{pag3.GetType().Name} with OrderNumber:{pag3.OrderNumber} cannot be configured as a personal access group ( # greater than {AccessGroupLimits.PersonalAccessGroup - 1 } )");
                // see if it can be re-assigned to 4
                //if (ag4 != null && ag4.AccessGroupNumber < Common.Constants.AccessGroupLimits.PersonalAccessGroup)
                //{   // swap ag3 and ag4
                //    var tempUid3 = ag3.AccessGroupUid;
                //    var tempUid4 = ag4.AccessGroupUid;
                //    pag3.AccessGroupUid = tempUid4;
                //    pag4.AccessGroupUid = tempUid3;
                //}
                //else
                //    throw new Exception($"{pag3.GetType().Name} with OrderNumber:{pag3.OrderNumber} cannot be configured as a personal access group");
                //// if it cannot be re-assigned, throw an exception
            }
            else
            {
                if (ag3 != null)
                {
                    pag3.AccessGroupUid = ag3.AccessGroupUid;
                }
            }

        //    foreach (var pag in assignedAccessGroups)
        //    {
        //        var ag = allAccessGroups.FirstOrDefault(o => o.AccessGroupUid == pag.AccessGroupUid);
        //        switch (pag.OrderNumber)
        //        {
        //            case 1:
        //            case 2:
        //                // Check to see if the access group is an extended group. If so, this is not permitted. Check to see if it can be re-assigned to either position 3 or 4
        //                if (ag != null && ag.AccessGroupNumber > GalaxySMS.Common.Constants.AccessGroupLimits.UnlimitedAccess)
        //                    throw new Exception($"{pag.GetType().Name} with OrderNumber:{pag.OrderNumber} cannot be configured as an extended access group");
        //                break;

        //            case 3:
        //                if (ag != null && ag.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.PersonalAccessGroup)
        //                    throw new Exception($"{pag.GetType().Name} with OrderNumber:{pag.OrderNumber} cannot be configured as the personal access group");
        //                break;

        //            case 4:
        //                break;
        //        }

        //    }
        }

        public static AccessGroup SelectAccessGroupFromValues(ref IEnumerable<AccessGroup> accessGroups, IAccessGroupAssignment accessGroupValues)
        {
            var allAgs = accessGroups.ToList();
            AccessGroup ag = null;
            if (accessGroups != null)
            {
                // If the AccessGroupUid is not Empty, look it up to make sure it exists
                if (accessGroupValues.AccessGroupUid != Guid.Empty)
                    ag = allAgs.FirstOrDefault(o => o.AccessGroupUid == accessGroupValues.AccessGroupUid);
                // If not found and a non-0 number is specified, look up by that number
                if (ag == null && accessGroupValues.AccessGroupNumber > AccessGroupLimits.None)
                    ag = allAgs.FirstOrDefault(o => o.AccessGroupNumber == accessGroupValues.AccessGroupNumber);
                // If not found and a name is specified is specified, look up by that name
                if (ag == null && !string.IsNullOrEmpty(accessGroupValues.AccessGroupName))
                    ag = allAgs.FirstOrDefault(o => o.Display == accessGroupValues.AccessGroupName);
                if( ag == null && 
                    accessGroupValues.AccessGroupUid == Guid.Empty &&
                    accessGroupValues.AccessGroupNumber == AccessGroupLimits.None &&
                    string.IsNullOrEmpty(accessGroupValues.AccessGroupName))
                    ag = allAgs.FirstOrDefault(o => o.AccessGroupNumber == accessGroupValues.AccessGroupNumber);
            }

            return ag;
        }
    }
}
