namespace Distance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDicCountries : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Afganistan','AF', 'AFG', GETDATE(), GETDATE(),'93')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Albania','AL', 'ALB', GETDATE(), GETDATE(),'355')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Algieria','DZ', 'DZA', GETDATE(), GETDATE(),'213')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Andora','AD', 'AND', GETDATE(), GETDATE(),'376')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Angola','AO', 'AGO', GETDATE(), GETDATE(),'244')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Arabia Saudyjska','SA', 'SAU', GETDATE(), GETDATE(),'966')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Argentyna','AR', 'ARG', GETDATE(), GETDATE(),'54')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Armenia','AM', 'ARM', GETDATE(), GETDATE(),'374')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Australia','AU', 'AUS', GETDATE(), GETDATE(),'61')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Austria','AT', 'AUT', GETDATE(), GETDATE(),'43')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Azerbejd�an','AZ', 'AZE', GETDATE(), GETDATE(),'994')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Bahrajn','BH', 'BHR', GETDATE(), GETDATE(),'973')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Bangladesz','BD', 'BGD', GETDATE(), GETDATE(),'880')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Belgia','BE', 'BEL', GETDATE(), GETDATE(),'32')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Benin','BJ', 'BEN', GETDATE(), GETDATE(),'229')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Bia�oru�','BY', 'BLR', GETDATE(), GETDATE(),'375')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Boliwia','BO', 'BOL', GETDATE(), GETDATE(),'591')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Bo�nia i Hercegowina','BA', 'BIH', GETDATE(), GETDATE(),'387')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Botswana','BW', 'BWA', GETDATE(), GETDATE(),'267')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Brazylia','BR', 'BRA', GETDATE(), GETDATE(),'55')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Brunei','BN', 'BRN', GETDATE(), GETDATE(),'673')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Bu�garia','BG', 'BGR', GETDATE(), GETDATE(),'359')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Burkina Faso','BF', 'BFA', GETDATE(), GETDATE(),'226')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Burundi','BI', 'BDI', GETDATE(), GETDATE(),'257')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Chile','CL', 'CHL', GETDATE(), GETDATE(),'56')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Chiny','CN', 'CHN', GETDATE(), GETDATE(),'86')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Chorwacja','HR', 'HRV', GETDATE(), GETDATE(),'385')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Cypr','CY', 'CYP', GETDATE(), GETDATE(),'357')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Czad','TD', 'TCD', GETDATE(), GETDATE(),'235')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Czechy','CZ', 'CZE', GETDATE(), GETDATE(),'420')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Dania','DK', 'DNK', GETDATE(), GETDATE(),'45')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('D�ibuti','DJ', 'DJI', GETDATE(), GETDATE(),'253')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Egipt','EG', 'EGY', GETDATE(), GETDATE(),'20')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Ekwador','EC', 'ECU', GETDATE(), GETDATE(),'593')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Erytrea','ER', 'ERI', GETDATE(), GETDATE(),'291')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Estonia','EE', 'EST', GETDATE(), GETDATE(),'372')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Etiopia','ET', 'ETH', GETDATE(), GETDATE(),'251')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Falklandy','FK', 'FLK', GETDATE(), GETDATE(),'500')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Fid�i','FJ', 'FJI', GETDATE(), GETDATE(),'679')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Filipiny','PH', 'PHL', GETDATE(), GETDATE(),'63')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Finlandia','FI', 'FIN', GETDATE(), GETDATE(),'358')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Francja','FR', 'FRA', GETDATE(), GETDATE(),'33')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Gabon','GA', 'GAB', GETDATE(), GETDATE(),'241')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Gambia','GM', 'GMB', GETDATE(), GETDATE(),'220')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Ghana','GH', 'GHA', GETDATE(), GETDATE(),'233')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Gibraltar','GI', 'GIB', GETDATE(), GETDATE(),'350')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Grecja','GR', 'GRC', GETDATE(), GETDATE(),'30')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Grenlandia','GL', 'GRL', GETDATE(), GETDATE(),'299')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Gruzja','GE', 'GEO', GETDATE(), GETDATE(),'995')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Guam','GU', 'GUM', GETDATE(), GETDATE(),'1671')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Gujana','GY', 'GUY', GETDATE(), GETDATE(),'592')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Gujana Francuska','GF', 'GUF', GETDATE(), GETDATE(),'594')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Gwinea','GN', 'GIN', GETDATE(), GETDATE(),'224')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Gwinea R�wnikowa','GQ', 'GNQ', GETDATE(), GETDATE(),'240')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Hiszpania','ES', 'ESP', GETDATE(), GETDATE(),'34')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Holandia','NL', 'NLD', GETDATE(), GETDATE(),'31')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Indie','IN', 'IND', GETDATE(), GETDATE(),'91')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Indonezja','ID', 'IDN', GETDATE(), GETDATE(),'62')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Irak','IQ', 'IRQ', GETDATE(), GETDATE(),'964')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Iran','IR', 'IRN', GETDATE(), GETDATE(),'98')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Irlandia','IE', 'IRL', GETDATE(), GETDATE(),'353')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Islandia','IS', 'ISL', GETDATE(), GETDATE(),'354')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Izrael','IL', 'ISR', GETDATE(), GETDATE(),'972')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Japonia','JP', 'JPN', GETDATE(), GETDATE(),'81')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Jemen','YE', 'YEM', GETDATE(), GETDATE(),'967')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Jordania','JO', 'JOR', GETDATE(), GETDATE(),'962')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Kambod�a','KH', 'KHM', GETDATE(), GETDATE(),'588')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Kamerun','CM', 'CMR', GETDATE(), GETDATE(),'237')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Kanada','CA', 'CAN', GETDATE(), GETDATE(),'1')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Katar','QA', 'QAT', GETDATE(), GETDATE(),'974')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Kazachstan','KZ', 'KAZ', GETDATE(), GETDATE(),'7')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Kenia','KE', 'KEN', GETDATE(), GETDATE(),'254')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Kirgistan','KG', 'KGZ', GETDATE(), GETDATE(),'996')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Kiribati','KI', 'KIR', GETDATE(), GETDATE(),'686')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Kolumbia','CO', 'COL', GETDATE(), GETDATE(),'57')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Komory','KM', 'COM', GETDATE(), GETDATE(),'269')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Kongo','CG', 'COG', GETDATE(), GETDATE(),'242')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Korea Po�udniowa','KR', 'KOR', GETDATE(), GETDATE(),'82')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Kostaryka','CR', 'CRI', GETDATE(), GETDATE(),'506')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Kuba','CU', 'CUB', GETDATE(), GETDATE(),'53')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Kuwejt','KW', 'KWT', GETDATE(), GETDATE(),'965')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Laos','LA', 'LAO', GETDATE(), GETDATE(),'856')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Lesotho','LS', 'LSO', GETDATE(), GETDATE(),'266')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Liban','LB', 'LBN', GETDATE(), GETDATE(),'961')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Liberia','LR', 'LBR', GETDATE(), GETDATE(),'231')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Libia','LY', 'LBY', GETDATE(), GETDATE(),'218')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Liechtenstein','LI', 'LIE', GETDATE(), GETDATE(),'423')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Litwa','LT', 'LTU', GETDATE(), GETDATE(),'370')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Luksemburg','LU', 'LUX', GETDATE(), GETDATE(),'352')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('�otwa','LV', 'LVA', GETDATE(), GETDATE(),'371')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Macedonia','MK', 'MKD', GETDATE(), GETDATE(),'389')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Madagaskar','MG', 'MDG', GETDATE(), GETDATE(),'261')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Makau','MO', 'MAC', GETDATE(), GETDATE(),'853')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Malawi','MW', 'MWI', GETDATE(), GETDATE(),'265')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Malediwy','MV', 'MDV', GETDATE(), GETDATE(),'960')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Malezja','MY', 'MYS', GETDATE(), GETDATE(),'60')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Mali','ML', 'MLI', GETDATE(), GETDATE(),'223')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Malta','MT', 'MLT', GETDATE(), GETDATE(),'356')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Maroko','MA', 'MAR', GETDATE(), GETDATE(),'212')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Mauretania','MR', 'MRT', GETDATE(), GETDATE(),'222')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Mauritius','MU', 'MUS', GETDATE(), GETDATE(),'230')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Meksyk','MX', 'MEX', GETDATE(), GETDATE(),'52')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Mo�dawia','MD', 'MDA', GETDATE(), GETDATE(),'373')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Monako','MC', 'MCO', GETDATE(), GETDATE(),'377')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Mongolia','MN', 'MNG', GETDATE(), GETDATE(),'976')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Mozambik ','MZ', 'MOZ', GETDATE(), GETDATE(),'258')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Namibia','NA', 'NAM', GETDATE(), GETDATE(),'264')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Nauru','NR', 'NRU', GETDATE(), GETDATE(),'674')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Nepal','NP', 'NPL', GETDATE(), GETDATE(),'977')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Niemcy','DE', 'DEU', GETDATE(), GETDATE(),'49')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Niger','NE', 'NER', GETDATE(), GETDATE(),'227')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Nigeria','NG', 'NGA', GETDATE(), GETDATE(),'234')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Nikaragua','NI', 'NIC', GETDATE(), GETDATE(),'505')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Niue','NU', 'NIU', GETDATE(), GETDATE(),'683')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Norwegia','NO', 'NOR', GETDATE(), GETDATE(),'47')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Nowa Kaledonia','NC', 'NCL', GETDATE(), GETDATE(),'687')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Nowa Zelandia','NZ', 'NZL', GETDATE(), GETDATE(),'64')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Oman','OM', 'OMN', GETDATE(), GETDATE(),'968')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Pakistan','PK', 'PAK', GETDATE(), GETDATE(),' 92')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Palau','PW', 'PLW', GETDATE(), GETDATE(),'680')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Palestyna','PS', 'PSE', GETDATE(), GETDATE(),'970')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Panama','PA', 'PAN', GETDATE(), GETDATE(),'507')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Paragwaj','PY', 'PRY', GETDATE(), GETDATE(),'595')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Peru','PE', 'PER', GETDATE(), GETDATE(),'51')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Polinezja Francuska','PF', 'PYF', GETDATE(), GETDATE(),'689')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Polska','PL', 'POL', GETDATE(), GETDATE(),'48')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Portugalia','PT', 'PRT', GETDATE(), GETDATE(),'351')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Portoryko','PR', 'PRI', GETDATE(), GETDATE(),'1787')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Republika �rodkowoafryka�ska','CF', 'CAF', GETDATE(), GETDATE(),'236')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Reunion','RE', 'REU', GETDATE(), GETDATE(),'262')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Rosja','RU', 'RUS', GETDATE(), GETDATE(),'7')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Rumunia','RO', 'ROU', GETDATE(), GETDATE(),'40')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Rwanda','RW', 'RWA', GETDATE(), GETDATE(),'250')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Saint Lucia','LC', 'LCA', GETDATE(), GETDATE(),'1758')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Salwador','SV', 'SLV', GETDATE(), GETDATE(),'503')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Samoa','WS', 'WSM', GETDATE(), GETDATE(),'684')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('San Marino','SM', 'SMR', GETDATE(), GETDATE(),'378')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Senegal','SN', 'SEN', GETDATE(), GETDATE(),'221')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Seszele','SC', 'SYC', GETDATE(), GETDATE(),'248')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Sierra Leone','SL', 'SLE', GETDATE(), GETDATE(),'232')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Singapur','SG', 'SGP', GETDATE(), GETDATE(),'65')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('S�owacja','SK', 'SVK', GETDATE(), GETDATE(),'421')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('S�owenia','SI', 'SVN', GETDATE(), GETDATE(),'386')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Somalia','SO', 'SOM', GETDATE(), GETDATE(),'252')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Sri Lanka','LK', 'LKA', GETDATE(), GETDATE(),'94')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Suazi','SZ', 'SWZ', GETDATE(), GETDATE(),'268')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Sudan','SD', 'SDN', GETDATE(), GETDATE(),'249')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Surinam','SR', 'SUR', GETDATE(), GETDATE(),'597')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Syria','SY', 'SYR', GETDATE(), GETDATE(),'963')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Szwajcaria','CH', 'CHE', GETDATE(), GETDATE(),'41')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Szwecja','SE', 'SWE', GETDATE(), GETDATE(),'46')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Tad�ykistan','TJ', 'TJK', GETDATE(), GETDATE(),'992')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Tajlandia','TH', 'THA', GETDATE(), GETDATE(),'66')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Tajwan','TW', 'TWN', GETDATE(), GETDATE(),'886')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Tanzania','TZ', 'TZA', GETDATE(), GETDATE(),'255')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Togo','TG', 'TGO', GETDATE(), GETDATE(),'228')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Tokelau','TK', 'TKL', GETDATE(), GETDATE(),'690')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Tonga','TO', 'TON', GETDATE(), GETDATE(),'676')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Tunezja','TN', 'TUN', GETDATE(), GETDATE(),'216')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Turcja','TR', 'TUR', GETDATE(), GETDATE(),'90')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Turkmenistan','TM', 'TKM', GETDATE(), GETDATE(),'993')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Tuvalu','TV', 'TUV', GETDATE(), GETDATE(),'688')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Uganda','UG', 'UGA', GETDATE(), GETDATE(),'256')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Ukraina','UA', 'UKR', GETDATE(), GETDATE(),'380')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Urugwaj','UY', 'URY', GETDATE(), GETDATE(),'598')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Uzbekistan','UZ', 'UZB', GETDATE(), GETDATE(),'998')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Vanuatu','VU', 'VUT', GETDATE(), GETDATE(),'678')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Wallis i Futuna','WF', 'WLF', GETDATE(), GETDATE(),'681')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Watykan','VA', 'VAT', GETDATE(), GETDATE(),'3906')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Wenezuela','VE', 'VEN', GETDATE(), GETDATE(),'58')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('W�gry','HU', 'HUN', GETDATE(), GETDATE(),'36')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Wielka Brytania','GB', 'GBR', GETDATE(), GETDATE(),'44')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Wietnam','VN', 'VNM', GETDATE(), GETDATE(),'84')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('W�ochy','IT', 'ITA', GETDATE(), GETDATE(),'39')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Wybrze�e Ko�ci S�oniowej','CI', 'CIV', GETDATE(), GETDATE(),'225')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Zambia','ZM', 'ZMB', GETDATE(), GETDATE(),'260')");
            Sql("INSERT INTO DicCountries(CountryName,CountryCodeA2,CountryCodeA3,CreateTime,ModifyTime,CountryDirectPhoneNumber) VALUES('Zimbabwe','ZW', 'ZWE', GETDATE(), GETDATE(),'263')");

        }

        public override void Down()
        {
        }
    }
}
