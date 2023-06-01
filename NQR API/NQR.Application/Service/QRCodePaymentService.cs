using AutoMapper;
using Microsoft.Extensions.Configuration;
using NQR.Application.Service.Interface;
using NQR.Common.Shared;
using NQR.Common.Shared.HttpService;
using NQR.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQR.Application.Service
{
	public class QRCodePaymentService : IQRCodePaymentService
	{
		private readonly IMapper _mapper;

		private readonly IConfiguration _configuration;

		public readonly IHttpService _httpService;

		public IAuthentication _auth;

		public QRCodePaymentService(IMapper mapper, IConfiguration configuration, IHttpService httpService, IAuthentication auth)
		{
			_mapper = mapper;
			_configuration = configuration;
			_httpService = httpService;
			_auth = auth;
		}


		public async Task<GenericResponse<QRCodePaymentResponse>> QRCodePayment(QRCodePaymentRequest qrcodePaymentRequest)
		{


			try
			{
				if (qrcodePaymentRequest == null)
				{
					return new GenericResponse<QRCodePaymentResponse>
					{
						ResponseCode = "99",
						ResponseMessage = $"QRCodeRequest object is null ",
						IsSuccessful = false,
						Data = null
					};
				}
				else if (string.IsNullOrEmpty(qrcodePaymentRequest.user_account_number) || string.IsNullOrEmpty(qrcodePaymentRequest.user_gps) || string.IsNullOrEmpty(qrcodePaymentRequest.order_amount) || string.IsNullOrEmpty(qrcodePaymentRequest.reference))
				{
					return new GenericResponse<QRCodePaymentResponse>
					{
						ResponseCode = "99",
						ResponseMessage = $"missing parameter",
						IsSuccessful = false,
						Data = null
					};
				}

				//var mapRequest = _mapper.Map<QRCodePaymentRequestSent>(qrcodePaymentRequest);
				var mapRequest = new QRCodePaymentRequestSent()
				{
					order_amount = qrcodePaymentRequest.order_amount,
					institution_number = _configuration.GetSection("Authentication")["Institution_Number"],
					user_account_name = qrcodePaymentRequest.user_account_number,
					user_account_number = qrcodePaymentRequest.user_account_number,
					user_bank_verification_number = qrcodePaymentRequest.user_bank_verification_number,
					user_gps = qrcodePaymentRequest.user_gps,
					order_sn = "",
					user_bank_no = qrcodePaymentRequest.user_bank_no,
					user_kyc_level = qrcodePaymentRequest.user_kyc_level,
					timestamp = "1581997091",
				};

				// get the mapRequest properties values

				//
				string parameterToString = $"institution_number={mapRequest.institution_number}&order_sn={mapRequest.order_sn}&order_amount={mapRequest.order_amount}&user_bank_no={mapRequest.user_bank_no}&user_account_name={mapRequest.user_account_name}&user_account_number={mapRequest.user_account_number}&user_bank_verification_number={mapRequest.user_bank_verification_number}&user_kyc_level={mapRequest.user_kyc_level}&user_gps={mapRequest.user_gps}&timestamp={mapRequest.timestamp}";
				string ApiKey = _configuration.GetSection("Authentication")["Apikey"];
				string signParameterValue = Util.CreateMD5($"{parameterToString}{ApiKey}").ToUpper();
				mapRequest.sign = signParameterValue;
				var authResponse = await _auth.GetToken();
				if (authResponse.ResponseCode == "00")
				{
					var req = new AuthPostRequest<QRCodePaymentRequestSent>
					{
						Url = _configuration.GetSection("EndpointUrl")["QRCodePayment"],
						authorization = authResponse.Data.access_token,
						Data = mapRequest
					};

					var response = await _httpService.SendAuthPostRequest<QRCodePaymentResponse, QRCodePaymentRequestSent>(req);

					if (response.ReturnCode == "Success")
					{
						return new GenericResponse<QRCodePaymentResponse>
						{
							ResponseCode = "00",
							ResponseMessage = $"Payment made successfully",
							IsSuccessful = true,
							Data = response
						};
					}

					else if (response.ReturnCode == "Inner")
					{
						return new GenericResponse<QRCodePaymentResponse>
						{
							ResponseCode = "00",
							ResponseMessage = $"Payment made successfully for intra-bank",
							IsSuccessful = true,
							Data = response
						};
					}
					else
					{
						return new GenericResponse<QRCodePaymentResponse>
						{
							ResponseCode = "99",
							ResponseMessage = $"Unable to generate qr code",
							IsSuccessful = false,
							Data = response
						};
					}
				}
				else
				{
					return new GenericResponse<QRCodePaymentResponse>
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
				return new GenericResponse<QRCodePaymentResponse>
				{
					ResponseCode = "99",
					ResponseMessage = $"Error occured while trying to generate qr code",
					IsSuccessful = false,
					Data = null
				};
			}
		}

		public async Task<GenericResponse<PaymentStatusResponse>> QRCodePaymentStatus(QRCodePaymentStatusRequest qrcodePaymentStatusRequest)
		{


			try
			{
				if (string.IsNullOrEmpty(qrcodePaymentStatusRequest.reference))
				{
					return new GenericResponse<PaymentStatusResponse>
					{
						ResponseCode = "99",
						ResponseMessage = $"missing parameter",
						IsSuccessful = false,
						Data = null
					};
				}

				var mapRequest = new PaymentStatusRequestSent()
				{
					//order_no = "202305181138119382008332",
					institution_number = _configuration.GetSection("Authentication")["Institution_Number"],
					order_sn = "",
					timestamp = "1581997091",
					order_no = qrcodePaymentStatusRequest.reference
				};
				string parameterToString = $"institution_number={mapRequest.institution_number}&order_no={mapRequest.order_no}&order_sn={mapRequest.order_sn}&timestamp={mapRequest.timestamp}";
				string ApiKey = _configuration.GetSection("Authentication")["Apikey"];
				string signParameterValue = Util.CreateMD5($"{parameterToString}{ApiKey}").ToUpper();
				mapRequest.sign = signParameterValue;
				var authResponse = await _auth.GetToken();
				if (authResponse.ResponseCode == "00")
				{
					var req = new AuthPostRequest<PaymentStatusRequestSent>
					{
						Url = _configuration.GetSection("EndpointUrl")["QRCodePaymentStatus"],
						authorization = authResponse.Data.access_token,
						Data = mapRequest
					};


					var response = await _httpService.SendAuthPostRequest<PaymentStatusResponse, PaymentStatusRequestSent>(req);
					if (response.ReturnCode == "Success")
					{
						return new GenericResponse<PaymentStatusResponse>
						{
							ResponseCode = "00",
							ResponseMessage = $"Payment status  successfully fetched",
							IsSuccessful = true,
							Data = response
						};
					}

					else
					{
						return new GenericResponse<PaymentStatusResponse>
						{
							ResponseCode = "99",
							ResponseMessage = $"Failed to fetch payment status",
							IsSuccessful = false,
							Data = response
						};
					}
				}

				else
				{
					return new GenericResponse<PaymentStatusResponse>
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
				return new GenericResponse<PaymentStatusResponse>
				{
					ResponseCode = "99",
					ResponseMessage = $"Internal error occured while trying to get payment status",
					IsSuccessful = false,
					Data = null
				};
			}
		}
	}
}
