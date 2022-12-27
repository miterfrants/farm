import {
    ApiHelper
} from '../util/api.js';

import {
    API
} from '../constants.js';

import {
    APP_CONFIG
} from '../config.js';

export const LogDataService = {
    GetList: async (strawberryId,page,limit) => {
        const api = APP_CONFIG.API_ENDPOINT + API.STRAWBERRY_LOGS;
        return ApiHelper.sendRequest(`${api.replace(/{strawberryId}/gi,strawberryId)}?page=${page || 1}&limit=${limit || 20}`, {
            method: 'GET'
        });
    },
    GetOne: async (strawberryId, id) => {
        const api = APP_CONFIG.API_ENDPOINT + API.STRAWBERRY_LOG;
        return ApiHelper.sendRequest(api.replace(/{strawberryId}/gi, strawberryId).replace(/{id}/gi,id), {
            method: 'GET'
        });
    },
    Update: async (strawberryId, id, data) => {
        const api = APP_CONFIG.API_ENDPOINT + API.STRAWBERRY_LOG;
        const requestBody = {
            ...data
        };
        return ApiHelper.sendRequest(api.replace(/{strawberryId}/gi, strawberryId).replace(/{id}/gi,id), {
            method: 'PATCH',
            body: JSON.stringify(requestBody)
        });
    },
    Create: async (strawberryId, id, data) => {
        const api = APP_CONFIG.API_ENDPOINT + API.STRAWBERRY_LOGS;
        const requestBody = {
            ...data
        };
        return ApiHelper.sendRequest(api.replace(/{strawberryId}/gi, strawberryId), {
            method: 'POST',
            body: JSON.stringify(requestBody)
        });
    }
};
