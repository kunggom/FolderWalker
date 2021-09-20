using System.Collections.Generic;

namespace FolderWalker
{
    /// <summary>
    /// 지정된 디렉터리의 하위 디렉터리를 순회(Traverse)하기 위해 사용하는 객체를 위한 인터페이스.
    /// </summary>
    public interface IDirTraverser : IEnumerable<string>
    {
        // empty
    }
}
