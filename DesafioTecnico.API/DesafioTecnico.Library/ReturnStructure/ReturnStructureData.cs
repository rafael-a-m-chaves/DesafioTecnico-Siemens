namespace DesafioTecnico.Library.ReturnStructure
{
    public class ReturnStructureData<ReturnData> :ReturnStructure
    {
        public ReturnStructureData(){ }

        public ReturnStructureData(ReturnData data) { Data = data; }

        public ReturnData Data { get; set; }
    }
}
