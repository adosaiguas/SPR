

namespace SPR
{
    public interface ISelfHostService
    {
        /// <summary>
        /// Run method.
        /// </summary>
        void Run();

        void ShutDown();

        void Stop();

    }
}
