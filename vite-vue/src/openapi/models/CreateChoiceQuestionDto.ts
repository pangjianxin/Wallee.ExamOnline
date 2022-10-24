/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ChoiceQuestionCategory } from './ChoiceQuestionCategory';
import type { CreateChoiceQuestionOptionDto } from './CreateChoiceQuestionOptionDto';

export type CreateChoiceQuestionDto = {
    category?: ChoiceQuestionCategory;
    title?: string | null;
    comment?: string | null;
    options?: Array<CreateChoiceQuestionOptionDto> | null;
};
