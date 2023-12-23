using Catalog.Core.Entities;

namespace Catalog.Application.Extensions
{
    public class UpdateProductBuilder
    {
        private readonly Product _product;

        public UpdateProductBuilder(Product product)
        {
            _product = product;
        }

        public UpdateProductBuilder Name(string name)
        {
            if (name.Equals(_product.Name))
                return this;

            _product.Name = name;
            return this;
        }

        public UpdateProductBuilder Description(string description)
        {
            if (description.Equals(_product.Description))
                return this;

            _product.Description = description;
            return this;
        }

        public UpdateProductBuilder Image(string image)
        {
            if (image.Equals(_product.Image))
                return this;

            _product.Image = image;
            return this;
        }

        public UpdateProductBuilder Price(decimal price)
        {
            if (price == _product.Price)
                return this;

            _product.Price = price;
            return this;
        }

        public UpdateProductBuilder Category(Category category)
        {
            if (category.Id.Equals(_product.Category.Id))
                return this;

            _product.Category = category;
            return this;
        }

        public UpdateProductBuilder IsDeleted(bool isDeleted)
        {
            if (isDeleted == _product.IsDeleted)
                return this;

            _product.IsDeleted = isDeleted;
            return this;
        }

        public Product Build()
            => _product;
    }
}
