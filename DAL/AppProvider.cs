namespace DAL
{
    public class AppProvider
    {
        BranchRepository branch;
        public BranchRepository Branch
        {
            get
            {
                if (branch == null)
                {
                    branch = new BranchRepository();
                }
                return branch;
            }
        }
        EmployeeRepository employee;
        public EmployeeRepository Employee
        {
            get
            {
                if (employee == null)
                {
                    employee = new EmployeeRepository();
                }
                return employee;
            }
        }
        RatingRepository rating;
        public RatingRepository Rating
        {
            get
            {
                if (rating == null)
                {
                    rating = new RatingRepository();
                }
                return rating;
            }
        }
        CommentRepository comment;
        public CommentRepository Comment
        {
            get
            {
                if (comment == null)
                {
                    comment = new CommentRepository();
                }
                return comment;
            }
        }

        AddressRepository address;
        public AddressRepository Address
        {
            get
            {
                if (address == null)
                {
                    address = new AddressRepository();
                }
                return address;
            }
        }
        AttributeValueRepository attributeValue;
        public AttributeValueRepository AttributeValue
        {
            get
            {
                if (attributeValue == null)
                {
                    attributeValue = new AttributeValueRepository();
                }
                return attributeValue;
            }
        }
        AttributeRepository attribute;
        public AttributeRepository Attribute
        {
            get
            {
                if (attribute == null)
                {
                    attribute = new AttributeRepository();
                }
                return attribute;
            }
        }
        ViewedRepository viewed;
        public ViewedRepository Viewed
        {
            get
            {
                if (viewed == null)
                {
                    viewed = new ViewedRepository();
                }
                return viewed;
            }
        }
        OrderRepository order;
        public OrderRepository Order
        {
            get
            {
                if (order == null)
                {
                    order = new OrderRepository();
                }
                return order;
            }
        } 
        ReceiptRepository receipt;
        public ReceiptRepository Receipt
        {
            get
            {
                if (receipt == null)
                {
                    receipt = new ReceiptRepository();
                }
                return receipt;
            }
        }
        BillRepository bill;
        public BillRepository Bill
        {
            get
            {
                if (bill == null)
                {
                    bill = new BillRepository();
                }
                return bill;
            }
        }
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
