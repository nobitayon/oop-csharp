namespace OfficeBuildingAutomationAPI
{
    public class Office
    {
        public bool IsLightOn = false;
        public bool IsSecuritySystemArmed = false;
        public int OfficeId = 0;
        private OfficeBuildingFakeWebService _officeBuildingFakeWebService = null;
        private int _securityToken = 0;
        public Office()
        {
            _officeBuildingFakeWebService = new OfficeBuildingFakeWebService();
        }

        public void Login(int officeId, string userName, string password)
        {
            _securityToken = _officeBuildingFakeWebService.Login(officeId,userName,password);
            if(_securityToken>0)
            {
                IsLightOn = _officeBuildingFakeWebService.IsLightOn(_securityToken);
                IsSecuritySystemArmed = _officeBuildingFakeWebService.IsSecuritySystemArmed(_securityToken);
                OfficeId = officeId;
            }
        }

        internal void ToggleLights()
        {
            if(IsLightOn)
            {
                _officeBuildingFakeWebService.SwitchLightsOff(_securityToken);
                IsLightOn = false;
            }
            else
            {
                _officeBuildingFakeWebService.SwitchLightsOn(_securityToken);
                IsLightOn = true;
            }
        }

        internal void ToggleSecuritySystem()
        {
            if(IsSecuritySystemArmed)
            {
                _officeBuildingFakeWebService.DisarmSecuritySystem(_securityToken);
                IsSecuritySystemArmed = false;
            }
            else
            {
                _officeBuildingFakeWebService.ArmSecuritySystem(_securityToken);
                IsSecuritySystemArmed = true;
            }
        }
    }
}
