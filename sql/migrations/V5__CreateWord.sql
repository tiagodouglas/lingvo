CREATE TABLE public."Words"(
	"Id" uuid NOT NULL,
	"Original" TEXT NULL,
    "Translated" TEXT NULL,
    "LanguageId" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "StatusId" INT NOT NULL,
    "Removed" BOOLEAN NULL,
    "TextId" uuid NOT NULL,
    "DateCreated" timestamptz NOT NULL,
	"DateUpdated" timestamptz,
	CONSTRAINT "Pk_WordsId" PRIMARY KEY ("Id"),
    CONSTRAINT "Fk_Languages_Words_Id"
      FOREIGN KEY("LanguageId") 
	  REFERENCES public."Languages"("Id"),
    CONSTRAINT "Fk_Users_Words_Id"
      FOREIGN KEY("UserId") 
	  REFERENCES public."Users"("Id"),
    CONSTRAINT "Fk_Lessons_Texts_Id"
      FOREIGN KEY("TextId") 
	  REFERENCES public."Texts"("Id")
);
