import {
    ApiHelper
} from '../util/api.js';

import {
    API
} from '../constants.js';

import {
    APP_CONFIG
} from '../config.js';

export const FilesService = {
    Upload: async (data, files) => {
        let api = APP_CONFIG.API_ENDPOINT + API.FILES;
        api = api.bind(data);

        var formData = new FormData();
        for (let i = 0; i < files.length; i++) {
            formData.append('files', files[i]);
        }
        return ApiHelper.sendRequest(api, {
            method: 'POST',
            headers: {
                'Content-Type': null
            },
            body: formData
        });
    },
};
