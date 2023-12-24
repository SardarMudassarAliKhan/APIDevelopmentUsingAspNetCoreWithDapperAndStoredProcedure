-- StpGetAllProducts: Get all products
CREATE PROCEDURE StpGetAllProducts
AS
BEGIN
    SELECT * FROM Products;
END

-- StpGetProductById: Get product by ID
CREATE PROCEDURE StpGetProductById
@Id INT
AS
BEGIN
    SELECT * FROM Products WHERE Id = @Id;
END

-- StpAddProduct: Add a new product
CREATE PROCEDURE StpAddProduct
    @Name NVARCHAR(100)
AS
BEGIN
    INSERT INTO Products (Name)
    VALUES (@Name);
    SELECT SCOPE_IDENTITY();
END

-- StpUpdateProduct: Update product by ID
CREATE PROCEDURE StpUpdateProduct
    @Id INT,
    @Name NVARCHAR(100)
AS
BEGIN
    UPDATE Products
    SET Name = @Name
    WHERE Id = @Id;
END
