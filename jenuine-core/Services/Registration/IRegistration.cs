using System.Collections.Generic;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Models;

namespace Its.Jenuiue.Core.Services.Assets
{
    public interface IRegistration
    {
        public void SetOrgId(string id);
        public MRegistration AddAsset(MRegistration param);
        public List<MRegistration> GetAssets(MRegistration param, QueryParam queryParam);
        public MRegistration GetAssetById(MRegistration param);
        public long GetAssetsCount();
        public MRegistration UpdateAsset(MRegistration param);
        public MRegistration UpdateAssetRegisterFlag(MRegistration param);
        public MRegistration DeleteAsset(MRegistration param);
    }
}
