namespace WebApp.Models
{
    public class SiteProviderContext : BaseProviderContext
    {
        MemberRepository member;
        public MemberRepository Member
        {
            get
            {
                if(member is null)
                {
                    member = new MemberRepository(Context);
                }
                return member;
            }
        }
        ProductRepositoryContext productContext;
        public ProductRepositoryContext ProductContext
        {
            get
            {
                if (productContext is null)
                {
                    productContext = new ProductRepositoryContext(Context);
                }
                return productContext;
            }
        }
        //BrandRepository brand;
        //public BrandRepository Brand
        //{
        //    get
        //    {
        //        if (brand is null)
        //        {
        //            brand = new BrandRepository(Context);
        //        }
        //        return brand;
        //    }
        //}
    }
}
