namespace WebApp.Models
{
    public class SiteProvider : BaseProvider
    {
        public SiteProvider(IConfiguration configuration) : base(configuration)
        {
        }
        CategoryRepository category;
        public CategoryRepository Category
        {
            get
            {
                if(category is null)
                {
                    category = new CategoryRepository(Connection);
                }
                return category;
            }
        }

        CarouselRepository carousel;
        public CarouselRepository Carousel
        {
            get
            {
                if (carousel is null)
                {
                    carousel = new CarouselRepository(Connection);
                }
                return carousel;
            }
        }

        SubCategoryRepository subCategory;
        public SubCategoryRepository SubCategory
        {
            get
            {
                if (subCategory is null)
                {
                    subCategory = new SubCategoryRepository(Connection);
                }
                return subCategory;
            }
        }

        BrandRepository brand;
        public BrandRepository Brand
        {
            get
            {
                if (brand is null)
                {
                    brand = new BrandRepository(Connection);
                }
                return brand;
            }
        }

        ProductRepository product;
        public ProductRepository Product
        {
            get
            {
                if (product is null)
                {
                    product = new ProductRepository(Connection);
                }
                return product;
            }
        }
        CartRepository cart;
        public CartRepository Cart
        {
            get
            {
                if (cart is null)
                {
                    cart = new CartRepository(Connection);
                }
                return cart;
            }
        }
        InvoiceRepository invoice;
        public InvoiceRepository Invoice
        {
            get
            {
                if (invoice is null)
                {
                    invoice = new InvoiceRepository(Connection);
                }
                return invoice;
            }
        }
        WardRepository ward;
        public WardRepository Ward
        {
            get
            {
                if (ward is null)
                {
                    ward = new WardRepository(Connection);
                }
                return ward;
            }
        }
        DistrictRepository district;
        public DistrictRepository District
        {
            get
            {
                if (district is null)
                {
                    district = new DistrictRepository(Connection);
                }
                return district;
            }
        }

        ProvinceRepository province;
        public ProvinceRepository Province
        {
            get
            {
                if (province is null)
                {
                    province = new ProvinceRepository(Connection);
                }
                return province;
            }
        }
        AddressRepository address;
        public AddressRepository Address
        {
            get
            {
                if (address is null)
                {
                    address = new AddressRepository(Connection);
                }
                return address;
            }
        }
    }
}
