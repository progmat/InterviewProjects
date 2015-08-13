using System;
using System.Collections.Generic;

namespace SignatureGroupConverter.Core
{
    public static class ListHelper
    {

        /// <summary>
        /// Transfor incoming individual item based "siggroup" list to a list containing groups of items, which groups can be assigned to original "siggroups"
        /// Result is ordered by group item count first (e.g. groups with 1 item come first), and after that ordered based on first item in the group (e.g. group containing A,C comes before B,D)
        /// Original siggroups:
        /// Siggroup1 (1st item of allLists): A,B,C,D,E,F 
        /// Siggroup2 (2nd item of allLists): A,      E  ,G
        /// Siggroup3 (3rd item of allLists):           F
        /// Result list of partner groups (in the order described above)
        /// PartnerGroup1: F
        /// PartnerGroup2: G
        /// PartnerGroup3: A,E
        /// PartnerGroup4: B,C,D
        /// Note: Original partner assignment can be done this way (not part of this excercise)
        /// Siggroup1: PartnerGroup1,3,4
        /// Siggroup2: PartnerGroup2,3
        /// Siggroup3: PartnerGroup1
        /// </summary>
        /// <param name="allLists">Partner assignemnt of siggroups</param>
        /// <returns>Partner groups in length/alphabetical order as above</returns>
        public static List<List<string>> TransformPartnerItemListToPartnerGroupList(List<List<string>> allLists)
        {
            throw new NotImplementedException();
        }
    }
}
