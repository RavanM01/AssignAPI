using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TaskVeren.Core.Entities;
using TaskVeren.DAL.Context;
using TaskVeren.DAL.Repositories.Interfaces;

namespace TaskVeren.DAL.Repositories.Implementations
{
    internal class TagRepository: Repository<Tag>, ITagRepository
    {
        public TagRepository(AppDBContext dBContext) : base(dBContext) { }

    }
}
