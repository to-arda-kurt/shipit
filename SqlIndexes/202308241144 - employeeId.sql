-- remove contraint
ALTER TABLE em DROP CONSTRAINT em_pkey;

ALTER TABLE public.em
    ADD COLUMN em_id SERIAL PRIMARY KEY;

CREATE INDEX name ON public.em (name);




-- ALTER TABLE em ADD em_id integer;

-- CREATE SEQUENCE public.em_p_id_seq
--     START WITH 1
--     INCREMENT BY 1
--     NO MINVALUE
--     NO MAXVALUE
--     CACHE 1;

-- UPDATE em SET em_id = public.em_p_id_seq.nextval;

-- ALTER TABLE ONLY public.em ALTER COLUMN em_id SET DEFAULT nextval('public.em_p_id_seq'::regclass);


-- ALTER TABLE em ADD em_id integer IDENTITY;
-- ALTER TABLE em ADD CONSTRAINT pk_id PRIMARY KEY (em_id);

-- ALTER TABLE em
--    ADD em_id INT IDENTITY
--        CONSTRAINT pk_id PRIMARY KEY CLUSTERED


