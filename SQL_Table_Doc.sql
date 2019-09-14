CREATE TABLE [dbo].[qa_users] (
    [qa_users_pk]    INT          IDENTITY (1, 1) NOT NULL,
    [qa_users_class_key] INT,
    [qa_users_name]  VARCHAR (80),
    [qa_users_login] VARCHAR (40),
    [qa_users_pass]  VARCHAR (60),
    [qa_users_email] VARCHAR (80),
    [qa_users_score] INT          DEFAULT ((0)),
    [qa_users_correct] INT DEFAULT((0)),
    [qa_users_incorrect] INT DEFAULT((0)),
    CONSTRAINT [PK_qa_users] PRIMARY KEY CLUSTERED ([qa_users_pk] ASC)
);

CREATE TABLE [dbo].[qa_admins] (
    [qa_admin_pk]    INT          IDENTITY (1, 1) NOT NULL,
    [qa_admin_login] INT,
    [qa_admin_password]  VARCHAR (80),
    CONSTRAINT [PK_qa_admin] PRIMARY KEY CLUSTERED ([qa_admin_pk] ASC)
);

CREATE TABLE [dbo].[qa_class] (
    [qa_class_pk]    INT          IDENTITY (1, 1) NOT NULL,
    [qa_class_title] INT,
    [qa_class_description]  TEXT,
    CONSTRAINT [PK_qa_class] PRIMARY KEY CLUSTERED ([qa_class_pk] ASC)
);

CREATE TABLE [dbo].[qa_questions] (
    [qa_questions_pk]    INT          IDENTITY (1, 1) NOT NULL,
    [qa_questions_class_key] INT,
    [qa_questions_lesson_key]  INT,
    [qa_questions_question]  TEXT,
    [qa_questions_answer_1]  TEXT,
    [qa_questions_answer_2]  TEXT,
    [qa_questions_answer_3]  TEXT,
    [qa_questions_answer_4]  TEXT,
    [qa_questions_answer_5]  TEXT,
    [qa_questions_correct]  INT,
    [qa_questions_incorrect]  INT,
    CONSTRAINT [PK_qa_questions] PRIMARY KEY CLUSTERED ([qa_questions_pk] ASC)
);