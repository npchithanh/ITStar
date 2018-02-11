namespace DAL
{
    public class AppProvider
    {
        SelectionRepository selection;
        public SelectionRepository Selection
        {
            get
            {
                if (selection == null)
                {
                    selection = new SelectionRepository();
                }
                return selection;
            }
        }

        PopularRepository popular;
        public PopularRepository Popular
        {
            get
            {
                if (popular == null)
                {
                    popular = new PopularRepository();
                }
                return popular;
            }
        }

        AttachmentRepository attachment;
        public AttachmentRepository Attachment
        {
            get
            {
                if (attachment == null)
                {
                    attachment = new AttachmentRepository();
                }
                return attachment;
            }
        }

        AttachmentTypeRepository attachmentType;
        public AttachmentTypeRepository AttachmentType
        {
            get
            {
                if (attachmentType == null)
                {
                    attachmentType = new AttachmentTypeRepository();
                }
                return attachmentType;
            }
        }

        FeatureRepository feature;
        public FeatureRepository Feature
        {
            get
            {
                if (feature == null)
                {
                    feature = new FeatureRepository();
                }
                return feature;
            }
        }

        AccountRepository acccount;
        public AccountRepository Acccount
        {
            get
            {
                if (acccount == null)
                {
                    acccount = new AccountRepository();
                }
                return acccount;
            }
        }

        SessionRepository session;
        public SessionRepository Session
        {
            get
            {
                if (session == null)
                {
                    session = new SessionRepository();
                }
                return session;
            }
        }

        WardRepository ward;
        public WardRepository Ward
        {
            get
            {
                if (ward == null)
                {
                    ward = new WardRepository();
                }
                return ward;
            }
        }
        DistrictRepository district;
        public DistrictRepository District
        {
            get
            {
                if (district == null)
                {
                    district = new DistrictRepository();
                }
                return district;
            }
        }

        ProfileRepository profile;
        public ProfileRepository Profile
        {
            get
            {
                if (profile == null)
                {
                    profile = new ProfileRepository();
                }
                return profile;
            }
        }

        ProvinceRepository province;
        public ProvinceRepository Province
        {
            get
            {
                if (province == null)
                {
                    province = new ProvinceRepository();
                }
                return province;
            }
        }

        RoleRepository role;
        public RoleRepository Role
        {
            get
            {
                if (role == null)
                {
                    role = new RoleRepository();
                }
                return role;
            }
        }
        CategoryRepository category;
        public CategoryRepository Category
        {
            get
            {
                if (category == null)
                {
                    category = new CategoryRepository();
                }
                return category;
            }
        }
    }
}
