import axios from 'axios';
import { baseUrl } from '../../configConnection.json'
// import { HTTPRequest } from '../httpRequest';

const getVendors = async(page, limmit) => {
    var res = await axios.get(baseUrl + '/Vendor/' + page + '/' + limmit);
    return res.data;
}

export default {
    getVendors
}