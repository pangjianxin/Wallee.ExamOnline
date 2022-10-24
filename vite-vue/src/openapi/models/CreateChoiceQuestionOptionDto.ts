/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ChoiceQuestionOptionIndex } from './ChoiceQuestionOptionIndex';

export type CreateChoiceQuestionOptionDto = {
    questionId?: string;
    content?: string | null;
    index?: ChoiceQuestionOptionIndex;
    isAnswer?: boolean;
};
