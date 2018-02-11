namespace DAL
{
    public class AppProvider
    {
        ProductRepository product;
        public ProductRepository Product
        {
            get
            {
                if (product == null)
                {
                    product = new ProductRepository();
                }
                return product;
            }
        }
        BrandRepository brand;
        public BrandRepository Brand
        {
            get
            {
                if (brand == null)
                {
                    brand = new BrandRepository();
                }
                return brand;
            }
        }

        CartRepository cart;
        public CartRepository Cart
        {
            get
            {
                if (cart == null)
                {
                    cart = new CartRepository();
                }
                return cart;
            }
        }
        CustomerRepository customer;
        public CustomerRepository Customer
        {
            get
            {
                if (customer == null)
                {
                    customer = new CustomerRepository();
                }
                return customer;
            }
        }
        SupplierRepository supplier;
        public SupplierRepository Supplier
        {
            get
            {
                if (supplier == null)
                {
                    supplier = new SupplierRepository();
                }
                return supplier;
            }
        }

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

        SupplierRepository profile;
        public SupplierRepository Profile
        {
            get
            {
                if (profile == null)
                {
                    profile = new SupplierRepository();
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
