namespace IocPerformance.Output
{
    public interface IOutput
    {
        void Start();

        void Result(Result result);

        void Finish();
    }
}
