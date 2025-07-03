import axios from "axios";

let baseUrl="https://localhost:44304/api/CurrencyConvert";

export const getRequestedAmount=(conversionObj)=>{
	return axios.post(`${baseUrl}/Convert`,conversionObj);
}

export const getAllCurrencies=()=>{
	return axios.get(`${baseUrl}/GetCurrenccies`);
}