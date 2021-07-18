import axios from 'axios';
import { baseUrl } from '../../configConnection.json'
// import { HTTPRequest } from '../httpRequest';

const getProfile = async(userName) => {
    var res = await axios.get(baseUrl + '/UserModel/' + userName);
    return res.data;
}

export default {
    getProfile
}