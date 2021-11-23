﻿using AutoMapper;
using BookStoreWebAPI.DbOperations;
using System;
using System.Linq;

namespace BookStoreWebAPI.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDBContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        public GetBookDetailQuery( BookStoreDBContext dBContext, IMapper mapper )
        {
            _dbContext = dBContext;
            _mapper = mapper;
        }
        public GetBookDetailModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.Id == BookId).SingleOrDefault();
            if ( book is null )
                throw new InvalidOperationException("This book is not found!!");
            GetBookDetailModel bookDetailModel = _mapper.Map<GetBookDetailModel>(book);
            return bookDetailModel;
        }
    }

}
