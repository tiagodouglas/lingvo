CREATE TABLE public."Texts"(
	"Id" uuid NOT NULL,
	"Name" varchar(50) NOT NULL,
    "AudioUri" TEXT NULL,
    "Body" TEXT NULL,
    "LanguageId" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "LessonId" uuid NOT NULL,
    "DateCreated" timestamptz NOT NULL,
	"DateUpdated" timestamptz,
	CONSTRAINT "Pk_TextId" PRIMARY KEY ("Id"),
    CONSTRAINT "Fk_Languages_Texts_Id"
      FOREIGN KEY("LanguageId") 
	  REFERENCES public."Languages"("Id"),
    CONSTRAINT "Fk_Users_Texts_Id"
      FOREIGN KEY("UserId") 
	  REFERENCES public."Users"("Id"),
    CONSTRAINT "Fk_Lessons_Texts_Id"
      FOREIGN KEY("LessonId") 
	  REFERENCES public."Lessons"("Id")
);

