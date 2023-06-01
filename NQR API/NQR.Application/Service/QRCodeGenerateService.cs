using AutoMapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NQR.Application.Service.Interface;
using NQR.Common.Shared;
using NQR.Common.Shared.HttpService;
using NQR.Model.Dto;

namespace NQR.Application.Service
{
    public class QRCodeGenerateService : IQRCodeService
	{
		private readonly IMapper _mapper;

		private readonly IConfiguration _configuration;

		public readonly IHttpService _httpService;

		public IAuthentication _auth;

		public QRCodeGenerateService(IMapper mapper, IConfiguration configuration, IHttpService httpService, IAuthentication auth)
		{
			_mapper = mapper;
			_configuration = configuration;
			_httpService = httpService;
			_auth = auth;
		}

		public GenericResponse<QrObjects> GetQrFieldObject(string qrdata)
		{
			try
			{
				//String qrdata = "0002010102121531*999166999166***M000000509526710018NG.COM.NIBSSPLC.QR0111S000000697302309991662207071551285194031919255204000053035665405120.55802NG5914Francis Abonyi6007Nigeria63046CFC";
				//gobjs.WriteError("NQR CODE string  " + qrdata);
				string MessageStart = qrdata.Substring(qrdata.IndexOf("0002") + 4, 2);
				//Console.WriteLine("MessageStart:  " + MessageStart);
				string extract1 = "0002" + MessageStart;
				qrdata = qrdata.Remove(qrdata.IndexOf(extract1), extract1.Length).Insert(qrdata.IndexOf(extract1), "");




				string FixedOrDynamic = qrdata.Substring(qrdata.IndexOf("0102") + 4, 2);
				//Console.WriteLine(FixedOrDynamic);

				string extract2 = "0102" + FixedOrDynamic;
				qrdata = qrdata.Remove(qrdata.IndexOf(extract2), extract2.Length).Insert(qrdata.IndexOf(extract2), "");


				string oringdata = qrdata;
				string InstNoPlusforwdNoPlusMerchNo = oringdata.Substring(oringdata.IndexOf("1531") + 4, 31);
				//Console.WriteLine("InstNoPlusforwdNoPlusMerchNo:  " + InstNoPlusforwdNoPlusMerchNo);


				string extract3 = "1531" + InstNoPlusforwdNoPlusMerchNo;
				qrdata = qrdata.Remove(qrdata.IndexOf(extract3), extract3.Length).Insert(qrdata.IndexOf(extract3), "");

				//string MerchantNumber = InstNoPlusforwdNoPlusMerchNo.Substring(InstNoPlusforwdNoPlusMerchNo.Length - 11);

				string SubMerchntNo = qrdata.Substring(qrdata.IndexOf("0111") + 4, 11);
				//Console.WriteLine(SubMerchntNo);


				string extract4 = "0111" + SubMerchntNo;
				qrdata = qrdata.Remove(qrdata.IndexOf(extract4), extract4.Length).Insert(qrdata.IndexOf(extract4), "");




				string OrderNo = "";
				if (FixedOrDynamic == "12")
				{
					OrderNo = qrdata.Substring(qrdata.IndexOf("0230") + 4, 30);
					//Console.WriteLine(OrderNo);

					string extract5 = "0230" + OrderNo;
					qrdata = qrdata.Remove(qrdata.IndexOf(extract5), extract5.Length).Insert(qrdata.IndexOf(extract5), "");
				}

				string CountryCode = qrdata.Substring(qrdata.IndexOf("5802") + 4, 2);
				//Console.WriteLine(CountryCode);

				string extract6 = "5802" + CountryCode;
				qrdata = qrdata.Remove(qrdata.IndexOf(extract6), extract6.Length).Insert(qrdata.IndexOf(extract6), "");


				string MerchantCategryCode = qrdata.Substring(qrdata.IndexOf("5204") + 4, 4);
				//Console.WriteLine(MerchantCategryCode);

				string extract7 = "5204" + MerchantCategryCode;
				qrdata = qrdata.Remove(qrdata.IndexOf(extract7), extract7.Length).Insert(qrdata.IndexOf(extract7), "");


				string CurrencyNumber = qrdata.Substring(qrdata.IndexOf("5303") + 4, 3);
				//Console.WriteLine(CurrencyNumber);

				string extract8 = "5303" + CurrencyNumber;
				qrdata = qrdata.Remove(qrdata.IndexOf(extract8), extract8.Length).Insert(qrdata.IndexOf(extract8), "");

				//Console.WriteLine("Remaining " + qrdata);




				//string AmountLengh = qrdata.Substring(qrdata.IndexOf("54") + 2, 2);
				//int AmountLenghInt = Convert.ToInt32(AmountLengh);
				//string AmountLenghPad = AmountLenghInt.ToString("D2");

				//string AmountLenghTagAndLendth = "54" + AmountLenghPad;
				//string Amount = qrdata.Substring(qrdata.IndexOf(AmountLenghTagAndLendth) + 4, AmountLenghInt);

				string MerchantNameLengh = qrdata.Substring(qrdata.IndexOf("59") + 2, 2);
				int MerchantNameLenghInt = Convert.ToInt32(MerchantNameLengh);
				string MerchantNamePad = MerchantNameLenghInt.ToString("D2");

				string MerchantNameTagAndLendth = "59" + MerchantNamePad;
				string MerchantName = qrdata.Substring(qrdata.IndexOf(MerchantNameTagAndLendth) + 4, MerchantNameLenghInt);

				int canchangeAmount = 1;

				string Amount = "";
				if (qrdata.Contains("54"))
				{
					canchangeAmount = 0;
					string AmountLengh = qrdata.Substring(qrdata.IndexOf("54") + 2, 2);
					int AmountLenghInt = Convert.ToInt32(AmountLengh);
					string AmountLenghPad = AmountLenghInt.ToString("D2");

					string AmountLenghTagAndLendth = "54" + AmountLenghPad;
					Amount = qrdata.Substring(qrdata.IndexOf(AmountLenghTagAndLendth) + 4, AmountLenghInt);
				}

				QrObjects qrobj = new QrObjects();
				qrobj.CanChangeAmount = canchangeAmount;
				qrobj.MessageStart = MessageStart;
				qrobj.FixedOrDynamic = FixedOrDynamic;
				qrobj.SubMerchntNo = SubMerchntNo;
				qrobj.OderNoForDynamice = OrderNo;
				qrobj.CountryCode = CountryCode;
				qrobj.MerchantCategryCode = MerchantCategryCode;
				qrobj.CurrencyNumber = CurrencyNumber;
				qrobj.MerchantName = MerchantName;
				qrobj.Amount = Amount;
				qrobj.InstNoPlusforwdNoPlusMerchNo = InstNoPlusforwdNoPlusMerchNo;
				//qrobj.MerchantNumber = MerchantNumber;
				return new GenericResponse<QrObjects>
				{
					ResponseCode = "00",
					ResponseMessage = $"infromation retrieved  successfully",
					IsSuccessful = true,
					Data = qrobj
				};

			}

			catch (Exception ex)
			{
				return new GenericResponse<QrObjects>
				{
					ResponseCode = "00",
					ResponseMessage = $"failed while trying to get your infromation",
					IsSuccessful = true,
					Data = null
				};
			}
		}

		public async Task<GenericResponse<DynamicQRCodeResponse>> GenerateDynamicQrCode(DynamicQRCodeRequest dynamicQRCodeRequest)
		{

			try
			{
				if (dynamicQRCodeRequest == null)
				{
					return new GenericResponse<DynamicQRCodeResponse>
					{
						ResponseCode = "99",
						ResponseMessage = $"QRCodeRequest object is null ",
						IsSuccessful = false,
						Data = null
					};
				}
				else if (string.IsNullOrEmpty(dynamicQRCodeRequest.sub_mch_no) || string.IsNullOrEmpty(dynamicQRCodeRequest.mch_no) || string.IsNullOrEmpty(dynamicQRCodeRequest.amount))
				{
					return new GenericResponse<DynamicQRCodeResponse>
					{
						ResponseCode = "99",
						ResponseMessage = $"missing parameter ",
						IsSuccessful = false,
						Data = null
					};
				}
				DateTime currentTime = DateTime.Now;
				 long timestamp = ((DateTimeOffset)currentTime).ToUnixTimeMilliseconds();
			     string timestampString = timestamp.ToString();
				 timestampString = timestampString.Substring(0, timestampString.Length - 3); 
				var mapRequest = new DynamicQRCodeRequestSent()
				{
					channel = "1",
					institution_number = _configuration.GetSection("Authentication")["Institution_Number"],
					mch_no = dynamicQRCodeRequest.mch_no,
					sub_mch_no = dynamicQRCodeRequest.sub_mch_no,
					code_type = "1",
					amount = dynamicQRCodeRequest.amount,
					order_no = "202305181138119382008332",
					order_type = "4",
					timestamp = timestampString
				};
				
				string parameterToString = $"amount={mapRequest.amount}&channel={mapRequest.channel}&code_type={mapRequest.code_type}&institution_number={mapRequest.institution_number}&mch_no={mapRequest.mch_no}&order_no={mapRequest.order_no}&order_type={mapRequest.order_type}&timestamp={mapRequest.timestamp}&sub_mch_no={mapRequest.sub_mch_no}";
				//string parameterToString = JsonConvert.SerializeObject(mapRequest);
				string ApiKey = _configuration.GetSection("Authentication")["Apikey"];
				string input = parameterToString.ToString() + ApiKey;
				string signParameterValue = Util.CreateMD5(input).ToUpper();
				//string signParameterValue = Util.SignPayload(parameterToString, ApiKey).ToUpper();
				mapRequest.sign = signParameterValue;
				var authResponse = await _auth.GetToken();

				if (authResponse.ResponseCode == "00")
				{

					var req = new AuthPostRequest<DynamicQRCodeRequestSent>
					{
						Url = _configuration.GetSection("EndpointUrl")["DynamicQrCode"],
						authorization = authResponse.Data.access_token,
						Data = mapRequest
					};

					var response = await _httpService.SendAuthPostRequest<DynamicQRCodeResponse, DynamicQRCodeRequestSent>(req);

					if (response.ReturnCode == "Success")
					{
						return new GenericResponse<DynamicQRCodeResponse>
						{
							ResponseCode = "00",
							ResponseMessage = $"Generate qr code successfully",
							IsSuccessful = true,
							Data = response
						};
					}

					return new GenericResponse<DynamicQRCodeResponse>
					{
						ResponseCode = "99",
						ResponseMessage = $"Unable to generate qr code",
						IsSuccessful = false,
						Data = response
					};
				}
				else
				{
					return new GenericResponse<DynamicQRCodeResponse>
					{
						ResponseCode = "99",
						ResponseMessage = $"failed to get a token",
						IsSuccessful = false,
						Data = null
					};
				}
			}

			

			catch (Exception ex)
			{
				return new GenericResponse<DynamicQRCodeResponse>
				{
					ResponseCode = "99",
					ResponseMessage = $"Error occured while trying to generate qr code",
					IsSuccessful = false,
					Data = null
				};
			}


		}


	}
}
