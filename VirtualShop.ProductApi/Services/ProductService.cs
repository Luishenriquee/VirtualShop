﻿using AutoMapper;
using VirtualShop.ProductApi.DTOs;
using VirtualShop.ProductApi.Models;
using VirtualShop.ProductApi.Repositories;

namespace VirtualShop.ProductApi.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var productEntity = await _productRepository.GetAll();
        return _mapper.Map<IEnumerable<ProductDTO>>(productEntity);
    }

    public async Task<ProductDTO> GetProductById(int id)
    {
        var productEntity = await _productRepository.GetById(id);
        return _mapper.Map<ProductDTO>(productEntity);
    }

    public async Task AddProduct(ProductDTO productDto)
    {
        Product product = _mapper.Map<Product>(productDto);
        await _productRepository.Create(product);
        productDto.Id = product.Id;
    }
    public async Task UpdateProduct(ProductDTO productDto)
    {
        Product product = _mapper.Map<Product>(productDto);
        await _productRepository.Update(product);
    }

    public async Task RemoveProduct(int id)
    {
        Product product = _productRepository.GetById(id).Result;
        await _productRepository.Delete(product.Id);
    }
}