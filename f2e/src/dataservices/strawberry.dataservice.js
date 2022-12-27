import {
    ApiHelper
} from '../util/api.js';

import {
    API
} from '../constants.js';

import {
    APP_CONFIG
} from '../config.js';

export const StrawberryDataService = {
    GetList: async () => {
        const api = APP_CONFIG.API_ENDPOINT + API.STRAWBERRIES;
        return ApiHelper.sendRequest(api, {
            method: 'GET'
        });
    },
    GetOne: async (id) => {
        const api = APP_CONFIG.API_ENDPOINT + API.STRAWBERRY;
        return ApiHelper.sendRequest(api.replace(/{id}/gi,id), {
            method: 'GET'
        });
    }
};
