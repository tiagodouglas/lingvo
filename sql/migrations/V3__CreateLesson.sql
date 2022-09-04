CREATE TABLE public."Lessons"(
	"Id" uuid NOT NULL,
	"Name" varchar(50) NOT NULL,
    "UserId" uuid NOT NULL,
    "LanguageId" uuid NOT NULL,
    "DateCreated" timestamptz NOT NULL,
	"DateUpdated" timestamptz,
	CONSTRAINT "Pk_LessonId" PRIMARY KEY ("Id"),
    CONSTRAINT "Fk_Languages_Lessons_Id"
      FOREIGN KEY("LanguageId") 
	  REFERENCES public."Languages"("Id"),
    CONSTRAINT "Fk_Users_Lessons_Id"
      FOREIGN KEY("UserId") 
	  REFERENCES public."Users"("Id")
);

