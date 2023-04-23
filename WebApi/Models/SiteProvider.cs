namespace WebApi.Models
{
    public class SiteProvider : BaseProvider
    {
        MemberRepository member;
        public MemberRepository Member
        {
            get
            {
                if (member is null)
                {
                    member = new MemberRepository(Context);
                }
                return member;
            }
        }
        BrandRepository brand;
        public BrandRepository Brand
        {
            get
            {
                if(brand is null)
                {
                    brand = new BrandRepository(Context);
                }
                return brand;
            }
           
        }

        CarouselRepository carousel;
        public CarouselRepository Carousel
        {
            get
            {
                if (carousel is null)
                {
                    carousel = new CarouselRepository(Context);
                }
                return carousel;
            }

        }
        CategoryRepository category;
        public CategoryRepository Category
        {
            get
            {
                if (category is null)
                {
                    category = new CategoryRepository(Context);
                }
                return category;
            }

        }
        ProductRepository product;
        public ProductRepository Product
        {
            get
            {
                if (product is null)
                {
                    product = new ProductRepository(Context);
                }
                return product;
            }

        }
    }
}
