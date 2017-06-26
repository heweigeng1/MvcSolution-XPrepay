using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xprepay.Data.Entities
{
    public class Dictionary : EntityBase
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Style { get; set; }
        public string Class { get; set; }
        /// <summary>
        /// 路径 id/id2/id3 主要用于描述树结构路径
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Index { get; set; }
        public Guid? ParentId { get; set; }
        /// <summary>
        /// 自关联父级
        /// </summary>
        public virtual Dictionary Parent { get; set; }
        //[JsonIgnore]
        public virtual ICollection<Dictionary> Childs { get; set; }
    }
}
