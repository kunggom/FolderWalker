using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace FolderWalker
{
    /// <summary>
    /// 깊이 우선 탐색(Depth-first search)을 통해 지정된 디렉터리의 하위 디렉터리를 순회(Traverse)하는 클래스.
    /// </summary>
    public class DepthFirstDirTraverser : IDirTraverser
    {
        // 재귀를 사용하지 않기 위해 별도의 스택을 만든다.
        private readonly Stack<string> _directories = new();

        /// <summary>
        /// DFS 순회를 위한 객체를 초기화한다.
        /// </summary>
        /// <param name="rootPath">순회가 시작될 디렉터리 경로 위치</param>
        /// <exception cref="ArgumentException">존재하지 않는 디렉터리 경로가 입력되었을 경우</exception>
        public DepthFirstDirTraverser(string rootPath)
        {
            if (!Directory.Exists(rootPath))
                throw new ArgumentException("This path does not exist.", nameof(rootPath));

            _directories.Push(rootPath);
        }

        /// <summary>
        /// 실제 순회를 실시한다.
        /// </summary>
        /// <returns>디렉터리 경로를 나타내는 문자열을 `foreach`로 가져다 쓰기 위한 IEnumerator</returns>
        public IEnumerator<string> GetEnumerator()
        {
            while (_directories.Count > 0)
            {
                var currentDir = _directories.Pop();
                yield return currentDir;

                string[] subDirectories;

                try
                {
                    subDirectories = Directory.GetDirectories(currentDir);
                }
                catch (Exception)
                {
                    continue; // 대부분의 예외는 해당 디렉터리에 접근할 권한이 없어서 발생하는데, 그냥 무시한다.
                }

                foreach (var dir in subDirectories)
                {
                    _directories.Push(dir);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
