import axios from 'axios';

let url = new URL(window.location.origin);
url.port = (url.protocol === 'http:' ? 8080 : 443).toString();
const baseURL = url + 'api/';

const instance = axios.create({
    baseURL: baseURL,
    headers: {
        'Content-Type': 'application/json'
    }
});
export default instance;


const defaultGetPrimitive = (name: any) => {
    return instance.get('/' + name);
};
const defaultGet = (name: any, id: any) => {
    return instance.get('/' + name + '/' + id);
};
const defaultCreate = (name: any, params: any) => {
    return instance.post('/' + name, params);
};
const defaultUpdate = (name: any, id: string, params: any) => {
    return instance.post('/' + name + '/' + id, params);
};
const defaultDelete = (name: any, id: any) => {
    return instance.delete('/' + name + '/' + id);
};

const defaultService = {
    getPrimitive: defaultGetPrimitive,
    get: defaultGet,
    create: defaultCreate,
    update: defaultUpdate,
    delete: defaultDelete,
};

export { defaultService };
