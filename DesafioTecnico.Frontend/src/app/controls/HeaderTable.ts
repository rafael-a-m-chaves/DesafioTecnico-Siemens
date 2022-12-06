export class HeaderFormat{
    value?:string
    style?:string
}

export class ClientHeader{
    header:HeaderFormat[] =  [
        {value:'Id', style:'width:5%; text:center;'},
        {value:'Nome', style:'width:27%; text:center;'},
        {value:'Idade', style:'width:5%; text:center;'},
        {value:'Data Nascimento', style:'width:10%; text:center;'},
        {value:'Sexo', style:'width:15%; text:center;'},
        {value:'Cidade/Estado', style:'width:10%; text:center;'},
        {value:'Ultima atualização', style:'width:13%; text:center;'},
        {value:'Ações', style:'width:10%; text:center;'}
    ]
}

export class CityHeader{
    header:HeaderFormat[] =  [
        {value:'Id', style:'width:5%; text:center;'},
        {value:'Nome', style:'width:35%; text:center;'},
        {value:'Estado', style:'width:35%; text:center;'},
        {value:'Ultima atulização', style:'width:15%; text:center;'},
        {value:'Ações', style:'width:10%; text:center;'}
    ]
}