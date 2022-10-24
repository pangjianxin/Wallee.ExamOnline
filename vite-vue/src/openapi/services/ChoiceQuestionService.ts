/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { ChoiceQuestionDto } from '../models/ChoiceQuestionDto';
import type { CombineType } from '../models/CombineType';
import type { CreateChoiceQuestionDto } from '../models/CreateChoiceQuestionDto';
import type { PagedResultDtoOfChoiceQuestionDto } from '../models/PagedResultDtoOfChoiceQuestionDto';
import type { UpdateChoiceQuestionDto } from '../models/UpdateChoiceQuestionDto';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class ChoiceQuestionService {

    /**
     * @param requestBody 
     * @returns ChoiceQuestionDto Success
     * @throws ApiError
     */
    public static choiceQuestionCreate(
requestBody?: CreateChoiceQuestionDto,
): CancelablePromise<ChoiceQuestionDto> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/app/choice-question',
            body: requestBody,
            mediaType: 'application/json',
            errors: {
                400: `Bad Request`,
                401: `Unauthorized`,
                403: `Forbidden`,
                404: `Not Found`,
                500: `Server Error`,
                501: `Server Error`,
            },
        });
    }

    /**
     * @param filter 
     * @param skipCount 
     * @param maxResultCount 
     * @param sorting 
     * @param combineWith 
     * @returns PagedResultDtoOfChoiceQuestionDto Success
     * @throws ApiError
     */
    public static choiceQuestionGetList(
filter?: string,
skipCount?: number,
maxResultCount?: number,
sorting?: string,
combineWith?: CombineType,
): CancelablePromise<PagedResultDtoOfChoiceQuestionDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/app/choice-question',
            query: {
                'Filter': filter,
                'SkipCount': skipCount,
                'MaxResultCount': maxResultCount,
                'Sorting': sorting,
                'CombineWith': combineWith,
            },
            errors: {
                400: `Bad Request`,
                401: `Unauthorized`,
                403: `Forbidden`,
                404: `Not Found`,
                500: `Server Error`,
                501: `Server Error`,
            },
        });
    }

    /**
     * @param id 
     * @param requestBody 
     * @returns ChoiceQuestionDto Success
     * @throws ApiError
     */
    public static choiceQuestionUpdate(
id: string,
requestBody?: UpdateChoiceQuestionDto,
): CancelablePromise<ChoiceQuestionDto> {
        return __request(OpenAPI, {
            method: 'PUT',
            url: '/api/app/choice-question/{id}',
            path: {
                'id': id,
            },
            body: requestBody,
            mediaType: 'application/json',
            errors: {
                400: `Bad Request`,
                401: `Unauthorized`,
                403: `Forbidden`,
                404: `Not Found`,
                500: `Server Error`,
                501: `Server Error`,
            },
        });
    }

    /**
     * @param id 
     * @returns any Success
     * @throws ApiError
     */
    public static choiceQuestionDelete(
id: string,
): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'DELETE',
            url: '/api/app/choice-question/{id}',
            path: {
                'id': id,
            },
            errors: {
                400: `Bad Request`,
                401: `Unauthorized`,
                403: `Forbidden`,
                404: `Not Found`,
                500: `Server Error`,
                501: `Server Error`,
            },
        });
    }

    /**
     * @param id 
     * @returns ChoiceQuestionDto Success
     * @throws ApiError
     */
    public static choiceQuestionGet(
id: string,
): CancelablePromise<ChoiceQuestionDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/app/choice-question/{id}',
            path: {
                'id': id,
            },
            errors: {
                400: `Bad Request`,
                401: `Unauthorized`,
                403: `Forbidden`,
                404: `Not Found`,
                500: `Server Error`,
                501: `Server Error`,
            },
        });
    }

}
