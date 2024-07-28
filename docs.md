### Atrya.com

**07-EntityFrameworkCore-part2**

24-ProductCategoryAbstractions



#### Steps:
**Domain Layer**

- create Domain Class Library

- create Models (ProductCategory, Product) in Aggregate directory

- create repositories interfaces(IProductCategoryRepository Interface, IProductRepositoryRepository Interface) in Aggregate directory
- IProductRepositoryInterface Contain methods:  Create, Get
- IProductCategoryRepositoryInterface Contain methods: Create, Get

#### Application Layer

* create Application Class Library

* create Application Contracts Class Library (contain application abstractions)

  ** Application Contracts**

  * CreateProductCategory (contain Name prop) (something like DTO)
  * EditProductCategory (contain Id prop). extends CreateProductCategory for get Name prop (something like DTO)
  * ProductCategoryViewModel (contain Id, Name, CreationDate prop)

#### Application Contrasts Layer

* create IProductCategoryApplication interface


    void Create (CreateProductCategory command);
    void Edit (EditProductCategory command);
    List<ProductCategoryViewModel> Search(string name);

#### Infrastructure Layer
* create Infrastructure Class Library
* install EF Core Libraries(EF, EF Design, EF Tools, EF Sql Server) from Nuget package manager.
* create my own DbContext file.
* add DbSets in DbContext
* create constructor, override OnModelCreating
* create Mapping directory and create models mapping (in Mapping directory).(ProductMapping, ProductCategoryMapping). extends IEntityTypeConfiguration
* in mappings define models columns and relationships
* in DbContext class OnModelCreating method define mappings.
* create repositories in Repository directory. implements repository interfaces that defined in Domain Layer
* create SaveChanges method in IProductCategoryRepository and implements it.
**Project queries**. (select the columns from tables that we want)
* create List of ProductCategoryViewModel in IProductCategoryRepository named Search(string name). and implement that


#### Application Layer
* create ProductCategoryApplication that implements IProductCategoryApplication. implements methods
* create Exists methods in IProductCategoryRepository and implement that.
* implements Create method in ProductCategoryApplication
* implement Edit method in ProductCategoryApplication
* implement Search method in ProductCategoryApplication